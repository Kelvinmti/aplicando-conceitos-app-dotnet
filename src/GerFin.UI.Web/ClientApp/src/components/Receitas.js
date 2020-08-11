import React, { Component } from 'react';

export class Receitas extends Component {
    displayName = Receitas.name;

    state = {
        dados: [],
        loading: true
    };   

    componentDidMount() {
        fetch('api/receitas')
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ dados: data, loading: false });
            });
    }

    listarReceitas = (receitas) => {
        console.log(receitas);
        return (
            <table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Descrição</th>
                        <th>Valor</th>
                    </tr>
                </thead>
                <tbody>
                    {receitas.map(receita => (
                        <tr key={receita.receitaId}>
                            <td>{receita.receitaId}</td>
                            <td>{receita.descricao}</td>
                            <td>{receita.valor}</td>
                        </tr>                     
                     ))}                    
                </tbody>
            </table>
        );
    }

    render() {
        let conteudos = this.state.loading ? <p><em>Loading...</em></p> : this.listarReceitas(this.state.dados);

        return (
            <div>
                {conteudos}
            </div>
        );
    }
}