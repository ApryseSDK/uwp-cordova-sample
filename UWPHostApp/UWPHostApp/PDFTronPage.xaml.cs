using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPHostApp
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class PDFTronPage : Page
	{
		public PDFTronPage()
		{
            this.InitializeComponent();

            pdftron.PDF.PDFViewCtrl myPDFViewCtrl = new pdftron.PDF.PDFViewCtrl();
            myPDFViewCtrl.SetupThumbnails(false, true, false, 250, 100 * 1024 * 1024, 0.1);
            myPDFViewCtrl.SetPagePresentationMode(pdftron.PDF.PDFViewCtrlPagePresentationMode.e_single_page);

            myPDFViewCtrl.SetBackgroundColor(Windows.UI.Colors.DarkGray);
            myPDFViewCtrl.SetPageSpacing(3, 3, 1, 1);
            myPDFViewCtrl.SetRelativeZoomLimits(pdftron.PDF.PDFViewCtrlPageViewMode.e_fit_page, 0.7, 5);
            myPDFViewCtrl.SetPageRefViewMode(pdftron.PDF.PDFViewCtrlPageViewMode.e_zoom);

            PDFViewBorder.Child = myPDFViewCtrl;

            var document = new pdftron.PDF.PDFDoc(Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "tiger.pdf"));
            myPDFViewCtrl.SetDoc(document);
        }
    }
}
