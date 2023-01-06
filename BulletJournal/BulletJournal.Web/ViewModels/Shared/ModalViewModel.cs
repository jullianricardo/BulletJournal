using Microsoft.AspNetCore.Html;

namespace BulletJournal.Web.ViewModels.Shared
{
    public class ModalViewModel
    {
        public string Id { get; set; }

        public string LabelId { get; set; }

        public string Title { get; set; }

        public string CloseButtonText { get; set; }

        public string ConfirmButtonText { get; set; }

        public Func<object, IHtmlContent> Content { get; set; }
    }
}
