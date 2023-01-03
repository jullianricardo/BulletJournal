using BulletJournal.Models.Domain;

namespace BulletJournal.Models
{
    public class Spread : Entity
    {
        public Page LeftPage { get; set; }

        public Page RightPage { get; set; }

        public SpreadStatus Status
        {
            get
            {
                if (LeftPage != null && RightPage != null)
                    return SpreadStatus.Full;

                if (LeftPage != null || RightPage != null)
                    return SpreadStatus.Incomplete;

                return SpreadStatus.Empty;
            }
        }

        public int GetLastPageNumber()
        {
            if (Status == SpreadStatus.Empty)
                return 0;

            if (Status == SpreadStatus.Full)
                return int.Max(LeftPage.Number, RightPage.Number);

            int pageNumber;
            if (RightPage != null)
                pageNumber = RightPage.Number;
            else
                pageNumber = LeftPage.Number;

            return pageNumber;
        }

        public Page GetLastPage()
        {
            int leftPageNumber = LeftPage?.Number ?? 0;
            int rightPageNumber = RightPage?.Number ?? 0;

            if (rightPageNumber > 0 && rightPageNumber > leftPageNumber)
                return RightPage;

            if (leftPageNumber > 0)
                return LeftPage;

            return null;
        }

        public Page GetFirstPage()
        {
            int leftPageNumber = LeftPage?.Number ?? 0;
            int rightPageNumber = RightPage?.Number ?? 0;

            if (leftPageNumber > 0 && leftPageNumber < rightPageNumber)
                return LeftPage;

            if (rightPageNumber > 0)
                return RightPage;

            return null;
        }

        public int GetFirstPageNumber()
        {
            if (Status == SpreadStatus.Empty)
                return 0;

            if (Status == SpreadStatus.Full)
                return int.Min(LeftPage.Number, RightPage.Number);

            int pageNumber;
            if (LeftPage != null)
                pageNumber = LeftPage.Number;
            else
                pageNumber = RightPage.Number;

            return pageNumber;
        }
    }

    public enum SpreadStatus
    {
        Empty,
        Incomplete,
        Full
    }
}