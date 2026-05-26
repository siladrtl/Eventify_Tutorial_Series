using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify_Tutorial_Series.Application.RequestParameters
{
    public record Pagination(int ItemCount=5, int PageCount = 0);
}
