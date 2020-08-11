using System;
using System.Collections.Generic;
using System.Text;

namespace GerFin.Infrastructure.Utils
{
    public static class PagingHelper
    {
        public const int RowsPerPage = 10;
        public static int Skip(int page)
        {
            return page == 1 ? 0 : (page * RowsPerPage) - RowsPerPage;
        }
    }
}
