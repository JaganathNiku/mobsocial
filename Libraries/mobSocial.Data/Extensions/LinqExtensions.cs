﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace mobSocial.Data.Extensions
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Returns last n elements from a sequence
        /// </summary>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int n)
        {
            var enumerable = source as IList<T> ?? source.ToList();
            return enumerable.Skip(Math.Max(0, enumerable.Count() - n));
        }

        /// <summary>
        /// Returns last n elements from a sequence
        /// </summary>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int n, int skip)
        {
            return source.TakeLast(n + skip).Take(n);
        }

        /// <summary>
        /// Returns specified number of elements after skipping previous pages
        /// </summary>
        public static IEnumerable<T> TakeFromPage<T>(this IEnumerable<T> source, int page, int count)
        {
            var enumerable = source as IList<T> ?? source.ToList();
            return enumerable.Skip((page - 1) * count).Take(count);
        }

        /// <summary>
        /// Returns elements from the last page considering specified count per page
        /// </summary>
        public static IEnumerable<T> TakeFromLastPage<T>(this IEnumerable<T> source, int countPerPage)
        {
            var enumerable = source as IList<T> ?? source.ToList();
            var totalPages = (int) Math.Ceiling((decimal) enumerable.Count() / countPerPage);
            return enumerable.TakeFromPage<T>(totalPages, countPerPage);

        }
    }
}