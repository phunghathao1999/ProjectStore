#pragma checksum "D:\Development\ProjectStore\ProjectStore\LaptopStore\Pages\Store\home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f623b8783b51801af26bc0b4608ec798faece0ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(LaptopStore.Pages.Store.Pages_Store_home), @"mvc.1.0.razor-page", @"/Pages/Store/home.cshtml")]
namespace LaptopStore.Pages.Store
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Development\ProjectStore\ProjectStore\LaptopStore\Pages\_ViewImports.cshtml"
using LaptopStore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f623b8783b51801af26bc0b4608ec798faece0ae", @"/Pages/Store/home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11c7933bd68b90b24bc3a7a429eacbf1bcfa8fe2", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Store_home : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Development\ProjectStore\ProjectStore\LaptopStore\Pages\Store\home.cshtml"
  
    Layout = "_LayoutStore";
    ViewData["Title"] = "Trang chủ";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- SECTION -->
<div class=""section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-4 col-xs-6"">
                <div class=""shop"">
                    <div class=""shop-img"">
                        <img src=""./img/shop01.png""");
            BeginWriteAttribute("alt", " alt=\"", 399, "\"", 405, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""shop-body"">
                        <h3>Laptop<br>Collection</h3>
                        <a href=""#"" class=""cta-btn"">Shop now <i class=""fa fa-arrow-circle-right""></i></a>
                    </div>
                </div>
            </div>
            <!-- /shop -->

            <!-- shop -->
            <div class=""col-md-4 col-xs-6"">
                <div class=""shop"">
                    <div class=""shop-img"">
                        <img src=""./img/shop03.png""");
            BeginWriteAttribute("alt", " alt=\"", 949, "\"", 955, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""shop-body"">
                        <h3>Accessories<br>Collection</h3>
                        <a href=""#"" class=""cta-btn"">Shop now <i class=""fa fa-arrow-circle-right""></i></a>
                    </div>
                </div>
            </div>
            <!-- /shop -->

            <!-- shop -->
            <div class=""col-md-4 col-xs-6"">
                <div class=""shop"">
                    <div class=""shop-img"">
                        <img src=""./img/shop02.png""");
            BeginWriteAttribute("alt", " alt=\"", 1504, "\"", 1510, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""shop-body"">
                        <h3>Cameras<br>Collection</h3>
                        <a href=""#"" class=""cta-btn"">Shop now <i class=""fa fa-arrow-circle-right""></i></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- /SECTION -->

<!-- SECTION -->
<div class=""section"">
    <!-- container -->
    <div class=""container"">
        <!-- row -->
        <div class=""row"">

            <!-- section title -->
            <div class=""col-md-12"">
                <div class=""section-title"">
                    <h3 class=""title"">Sản phẩm mới</h3>
                    <div class=""section-nav"">
                        <ul class=""section-tab-nav tab-nav"">
                            <li><a href=""javascript:void(0)"" data-toggle=""tab"" class=""home-catelogNewProduct"" id=""1000000"">Tất cả</a></li>
");
#nullable restore
#line 70 "D:\Development\ProjectStore\ProjectStore\LaptopStore\Pages\Store\home.cshtml"
                             foreach (var item in Model.catelogModels)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a href=\"javascript:void(0)\" data-toggle=\"tab\" class=\"home-catelogNewProduct\"");
            BeginWriteAttribute("id", " id=\"", 2664, "\"", 2677, 1);
#nullable restore
#line 72 "D:\Development\ProjectStore\ProjectStore\LaptopStore\Pages\Store\home.cshtml"
WriteAttributeValue("", 2669, item.id, 2669, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 72 "D:\Development\ProjectStore\ProjectStore\LaptopStore\Pages\Store\home.cshtml"
                                                                                                                           Write(item.catelogName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 73 "D:\Development\ProjectStore\ProjectStore\LaptopStore\Pages\Store\home.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </ul>
                    </div>
                </div>
            </div>
            <!-- /section title -->

            <!-- Products tab & slick -->
            <div class=""col-md-12"">
                <div class=""row"">
                    <div class=""products-tabs"">
                        <div id=""tab2"" class=""tab-pane fade in active"">
                            <div class=""products-slick"" data-nav=""#slick-nav-2"" id=""home-load-newProduct"">
                                
                            </div>
                            <div id=""slick-nav-2"" class=""products-slick-nav""></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- /SECTION -->


<!-- SECTION -->
<div class=""section"">
    <!-- container -->
    <div class=""container"">
        <!-- row -->
        <div class=""row"">

            <!-- section title -->
            <div class=""col-md-12"">
 ");
            WriteLiteral(@"               <div class=""section-title"">
                    <h3 class=""title"">Top selling</h3>
                    <div class=""section-nav"">
                        <ul class=""section-tab-nav tab-nav"">
                            <li><a href=""javascript:void(0)"" data-toggle=""tab"" class=""home-catelogTopSelling"" id=""1000000"">Tất cả</a></li>
");
#nullable restore
#line 113 "D:\Development\ProjectStore\ProjectStore\LaptopStore\Pages\Store\home.cshtml"
                             foreach (var item in Model.catelogModels)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a href=\"javascript:void(0)\" data-toggle=\"tab\" class=\"home-catelogTopSelling\"");
            BeginWriteAttribute("id", " id=\"", 4327, "\"", 4340, 1);
#nullable restore
#line 115 "D:\Development\ProjectStore\ProjectStore\LaptopStore\Pages\Store\home.cshtml"
WriteAttributeValue("", 4332, item.id, 4332, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 115 "D:\Development\ProjectStore\ProjectStore\LaptopStore\Pages\Store\home.cshtml"
                                                                                                                           Write(item.catelogName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 116 "D:\Development\ProjectStore\ProjectStore\LaptopStore\Pages\Store\home.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </ul>
                    </div>
                </div>
            </div>
            <!-- /section title -->

            <!-- Products tab & slick -->
            <div class=""col-md-12"">
                <div class=""row"">
                    <div class=""products-tabs"">
                        <div id=""tab2"" class=""tab-pane fade in active"">
                            <div class=""products-slick"" data-nav=""#slick-nav-2"" id=""home-load-TopSelling"">
                                
                            </div>
                            <div id=""slick-nav-2"" class=""products-slick-nav""></div>
                        </div>
                        <!-- /tab -->
                    </div>
                </div>
            </div>
            <!-- /Products tab & slick -->
        </div>
        <!-- /row -->
    </div>
    <!-- /container -->
</div>
<!-- /SECTION -->
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LaptopStore.Pages.Store.homeModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LaptopStore.Pages.Store.homeModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LaptopStore.Pages.Store.homeModel>)PageContext?.ViewData;
        public LaptopStore.Pages.Store.homeModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
