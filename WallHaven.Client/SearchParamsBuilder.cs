using System.Text;

namespace WallHaven.Client
{
    public enum Sorting
    {
        date_added = 1,
        relevance = 2,
        random = 3,
        views = 4,
        favourites = 5,
        toplist = 6
    }

    public enum OrderBy
    {
        desc = 1,
        asc = 2
    }

    public class SearchParamsBuilder
    {
        private int _minWidth;
        private int _minHeight;
        private bool _searchGeneral;
        private bool _searchAnime;
        private bool _searchPeople;
        private bool _searchSFW;
        private bool _searchSketchy;
        private bool _searchNSFW;
        private Sorting _sorting;
        private OrderBy _orderBy;

        public string Build()
        {
            StringBuilder builder = new();

            builder.Append($"?");

            if (_minHeight is not 0 && _minWidth is not 0)
            {
                builder.Append($"&atleast={_minWidth}x{_minHeight}");
            }

            string categories = string.Empty;
            categories += _searchGeneral ? "1" : "0";
            categories += _searchAnime ? "1" : "0";
            categories += _searchPeople ? "1" : "0";
            builder.Append($"&categories={categories}");

            string purity = string.Empty;
            purity += _searchSFW ? "1" : "0";
            purity += _searchSketchy ? "1" : "0";
            purity += _searchNSFW ? "1" : "0";
            builder.Append($"&purity={purity}");

            builder.Append($"&sorting={_sorting}");
            builder.Append($"&order={_orderBy}");


            // Remove first & and replace with ?
            //var finalQueryString = builder.ToString();
            //if (finalQueryString[0] is '&')
            //{
            //    finalQueryString = finalQueryString.Substring(1, finalQueryString.Length);
            //}

            //if (finalQueryString[0] is not '?')
            //{
            //    return $"?{finalQueryString}";
            //}

            //return finalQueryString;
            return builder.ToString();
        }

        public SearchParamsBuilder WithMinimumResolution(int width, int height)
        {
            _minHeight = height;
            _minWidth = width;
            return this;
        }

        public SearchParamsBuilder IncludeGeneral(bool includeGeneral)
        {
            _searchGeneral = includeGeneral;
            return this;
        }

        public SearchParamsBuilder IncludeAnime(bool includeAnime)
        {
            _searchAnime = includeAnime;
            return this;
        }

        public SearchParamsBuilder IncludePeople(bool includePeople)
        {
            _searchPeople = includePeople;
            return this;
        }

        public SearchParamsBuilder IncludeSafe(bool includeSafe)
        {
            _searchSFW = includeSafe;
            return this;
        }

        public SearchParamsBuilder IncludeSketchy(bool includeSketchy)
        {
            _searchSketchy = includeSketchy;
            return this;
        }

        public SearchParamsBuilder IncludeNSFW(bool includeNSFW)
        {
            _searchNSFW = includeNSFW;
            return this;
        }

        public SearchParamsBuilder SortBy(Sorting sorting)
        {
            _sorting = sorting;
            return this;
        }

        public SearchParamsBuilder OrderBy(OrderBy orderBy)
        {
            _orderBy = orderBy;
            return this;
        }
    }
}