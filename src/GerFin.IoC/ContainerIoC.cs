using GerFin.ApplicationCore.AutoMapper;
using GerFin.ApplicationCore.Entity;
using GerFin.ApplicationCore.Repositories.Interfaces;
using GerFin.ApplicationCore.Services.Classes;
using GerFin.ApplicationCore.Services.Interfaces;
using GerFin.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace GerFin.IoC
{
    public static class ContainerIoC
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AddSingleton(AutoMapperHelper.CreateMapper());
            RegistrarRepositorios(services);
            RegistrarServicos(services);
        }

        private static List<Type> BuscarComponente(string nomeAssembly, string namespaceAssembly, string excludeName, TipoComponente tipo)
        {
            if (tipo == TipoComponente.Interface)
            {
                // EXCLUINDO INTERFACE GENERICS
                return Assembly.Load(nomeAssembly)
                                                     .GetTypes()
                                                     .Where(x => !string.IsNullOrEmpty(x.Namespace))
                                                     .Where(x => x.IsInterface)
                                                     .Where(x => x.Namespace == namespaceAssembly)
                                                     .Where(x => !x.Name.Contains(excludeName))
                                                     .ToList();
            }

            return Assembly.Load(nomeAssembly)
                                              .GetTypes()
                                              .Where(x => !string.IsNullOrEmpty(x.Namespace))
                                              .Where(x => x.IsClass)
                                              .Where(x => x.Namespace == namespaceAssembly)
                                              .Where(x => !x.IsAbstract)
                                              .Where(x => !x.Name.StartsWith(excludeName))
                                              .Where(x => !x.Name.Contains("<"))
                                              .ToList();
        }

        private static void RegistrarRepositorios(IServiceCollection services)
        {
            // EXCLUINDO INTERFACE GENERICS
            List<Type> interfacesToRegister = BuscarComponente("GerFin.ApplicationCore", "GerFin.ApplicationCore.Repositories.Interfaces", "IRepository", TipoComponente.Interface);

            // EXCLUINDO CLASSE GENERICS
            List<Type> implementationToRegister = BuscarComponente("GerFin.Infrastructure", "GerFin.Infrastructure.Repositories", "Repository", TipoComponente.Classe);

            Registrar(services, interfacesToRegister, implementationToRegister, TipoRegistro.Scoped);
        }

        private static void Registrar(IServiceCollection services, 
                                      List<Type> interfacesToRegister, 
                                      List<Type> implementationToRegister,
                                      TipoRegistro tipoRegistro)
        {
            Type impl;
            foreach (Type item in interfacesToRegister)
            {
                impl = implementationToRegister.FirstOrDefault(x => x.Name == item.Name.Substring(1));
                if (impl != null)
                {
                    switch (tipoRegistro)
                    {
                        case TipoRegistro.Scoped:
                            services.AddScoped(item, impl);
                            break;
                        case TipoRegistro.Transient:
                            services.AddTransient(item, impl);
                            break;
                    }
                    
                }// SE NAO ACHAR LOGAR ERRO, ALGUM SERVICO NAO IRA FUNCIONAR
            }
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
            List<Type> interfacesToRegister = BuscarComponente("GerFin.ApplicationCore", "GerFin.ApplicationCore.Services.Interfaces", "IService", TipoComponente.Interface);

            List<Type> implementationToRegister = BuscarComponente("GerFin.ApplicationCore", "GerFin.ApplicationCore.Services.Classes", "Service", TipoComponente.Classe);

            Registrar(services, interfacesToRegister, implementationToRegister, TipoRegistro.Transient);
        }

        enum TipoRegistro
        {
            Scoped,
            Transient
        }

        enum TipoComponente
        {
            Interface,
            Classe
        }
    }
}
