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
            int leftPageNumber, rightPageNumber, lastPageNumber;
            leftPageNumber = rightPageNumber = 0;

            if (RightPage != null)
                rightPageNumber = RightPage.Number;

            if (LeftPage != null)
                leftPageNumber = LeftPage.Number;

            lastPageNumber = int.Max(leftPageNumber, rightPageNumber);
            return lastPageNumber;
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
            int leftPageNumber, rightPageNumber, firstPageNumber;
            leftPageNumber = rightPageNumber = 0;

            if (RightPage != null)
                rightPageNumber = RightPage.Number;

            if (LeftPage != null)
                leftPageNumber = LeftPage.Number;

            firstPageNumber = int.Min(leftPageNumber, rightPageNumber);
            return firstPageNumber;
        }
    }

    public enum SpreadStatus
    {
        Empty,
        Incomplete,
        Full
    }
}