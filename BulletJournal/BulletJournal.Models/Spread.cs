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