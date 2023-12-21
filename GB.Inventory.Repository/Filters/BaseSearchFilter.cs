using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Inventory.Repository.Filters
{
	public class BaseSearchFilter
	{
		public int PageNumber { get; set; } = 1;
        private int _pageSize = 0;

        public int PageSize
        {
            get { return _pageSize == 0 ? int.MaxValue : _pageSize; }
            set { _pageSize = value; }
        }

        public int Skip
		{
			get
			{
				return (PageNumber - 1) * PageSize;
			}
		}
	}
}
