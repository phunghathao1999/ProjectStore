using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Models
{
    public class PaginationList<T>
    {
        public PaginationList(IEnumerable<T> _pageOfItems, int _currentPage, int _pageSize, int _totalItem, int _totalPage, int _countOfPage)
        {
            currentPage = _currentPage;
            pageSize = _pageSize;
            totalItem = _totalItem;
            totalPage = _totalPage;
            countOfPage = _countOfPage;
            pageOfItems = _pageOfItems;
        }
        public IEnumerable<T> pageOfItems { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int totalItem { get; set; }
        public int totalPage { get; set; }
        public int countOfPage { get; set; }
        public bool HasPrevious
        {
            get { return currentPage > 0; }
        }
        public bool HasNext
        {
            get { return currentPage < totalPage - 1; }
        }

        public static Object Create(IEnumerable<T> source, int currentPage, int pageSize)
        {
            int totalItems = source.Count<T>();
            var pageOfItems = source.Skip(currentPage * pageSize).Take<T>(pageSize).ToList();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var countOfPage = pageOfItems.Count();

            PaginationList<T> paginationList = new PaginationList<T>(pageOfItems, currentPage, pageSize, totalItems, totalPages, countOfPage);
            return paginationList;
        }
    }
}