using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Roadway.Infrastructure.Pagination
{
    public static class PagingExtension
    {
        public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int page, int size)
        {
            return source.Skip((page - 1) * size).Take(size);
        }
        
        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int page, int size)
        {
            return source.Skip((page - 1) * size).Take(size);
        }
    }
}