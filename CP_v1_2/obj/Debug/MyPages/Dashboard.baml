   M S B A M L   `   `   `  ????B  >CP_v1_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CP_v1_2.MyPagesCP_v1_2.MyPages  5      1clr-namespace:CP_v1_2.ClassesCP_v1_2.Classes  5          CP_v1_2.MyPages.Dashboard   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	 cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah
 dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.VaadinIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.ForkAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a^ ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Coolicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Fontisto, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.FileIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.PixelartIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Codicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am  iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai! eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah" dMahApps.Metro.IconPacks.Fontaudio, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah# dMahApps.Metro.IconPacks.RemixIcon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af$ bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai% eMahApps.Metro.IconPacks.RadixIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137axIcon-http://metro.mahapps.com/winfx/xaml/iconpacks!     	 
                        ! " # $ % 5      ilocalclr-namespace:CP_v1_2.MyPages!     	 
                        ! " # $ % 5      hconvclr-namespace:CP_v1_2.Classes!     	 
                        ! " # $ % 5        N? Title$  	Dashboard??5       ? 	Resources 5      +   %CP_v1_2.Classes.BolleanToIntConverter   TypeConv/   )CP_v1_2.Classes.DateTimeToStringConverter  DateConv.   (CP_v1_2.Classes.DecimalToStringConverter  PercentConv??%W   &	        &	      &	 &       5   
   6%     5   
   6)     5   
   6(   5      .??5      ? .+?5   
   ?? $??Today cashflow??6   ???#f0f0f0$??80 20q?5      $??50??5      $	??300??5       ?? TextAlignment$ Center=?5      $
??Left=?5      $	??Top=?5      $??30(?5      ? 5   
   $	??300??6   $	??450??6   $
??Left=?5      $	??Top=?5       $??	10 80 0 0q?6(   .+?5"      &   System.Windows.Controls.DataGrid  -   5          Name$ dtg_Info??5"         HeadersVisibility$
 None=?5#        dtg_Info#??[ 5$        dtg_Info_DTGRow   RowStyle# [ 5%         Columns 5&      4  .System.Windows.Controls.DataGridTemplateColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 45 6-      CellTemplate 5(      ?? 5)      .R?5*   "   ?? .+?5+   &   . 	 (MahApps.Metro.IconPacks.PackIconMaterial  	   Kind$	 ArrowDownBold=?6<   
??? ? ?y?5-   8   ?? *	CatType+
 ?? ConverterParameter$

 True?? ?? 	Converter# [    5.   &   $	 ArrowUpBold=?6<   
???  ??y?50   8   ?? *	CatType+$
 False??# [  51   #   52      54      0	  *System.Windows.Controls.DataGridTextColumn	  55      1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6)   ?? *Nom+	  56       6)   ?? *Sum+	  57       6)   ?? *Date+$
 False??# [ 59      5:      ?? 5<   
   $??Current wallets state??6   ???#f0f0f0$??
580,20,0,0q?5>      $??50??5?      $	??300??5@      $ Center=?5A      $
??Left=?5B      $	??Top=?5C      $??30(?5D      ? 5E   
   $	??300??6   $	??450??6   $
??Left=?5F      $	??Top=?5G      $??
510 80 0 0q?6(   .+?5I        -   5        $ dtg_InfoWallet??5I      $
 None=?5J      #??[ 5K      # [ 5L       5M        5N      $ 45 6-    5O      ?? 5P      .R?5R   "     $	 FolderDownloadOutline=?68   
???????5S   8   5T      5V      	  5W       6)   ?? *Wallet+	  5X       6)   ?? *Sum+5Z      5[      ?? 5]   
   $%??Implementation of current plans??6   ???#f0f0f0$??
20,400,0,0q?5_      $??50??5`      $	??450??5a      $ Center=?5b      $
??Left=?5c      $	??Top=?5d      $??30(?5e      ? 5f   
   $	??300??6   $	??450??6   $
??Left=?5g      $	??Top=?5h      $??
10 460 0 0q?6(   .+?5j        -   5        $ dtg_PlansInfo??5j      $
 None=?5k      #??[ 5l      # [ 5m       5n      	  5o       6)   ?? *
Category+	  5p       6)   ?? *Sum+	  5q       6)   ?? *	Percent+# [ 	  5r       6)   ?? *
Currency+5t      5u      ?? 5w   
   $??Current exchange course??6   ???#f0f0f0$??550 400 0 0q?5y      $??50??5z      $	??350??5{      $
??Left=?5|      $	??Top=?5}      $ Center=?5~      $??30(?5      ? 5?   
   $	??300??6   $	??450??6   $
??Left=?5?      $	??Top=?5?      $??510 460 0 0q?5?      .+?5?        -   5        $ dtg_CursInfo??5?      $
 None=?5?      #??[ 5?      # [ 5?      $??10 0 0 0q?5?       5?      	  5?      $ 50 6F    6)   ?? *
Currency+6F   	  5?      $ 50 6@    6)   ?? *To+6@   	  5?      $	 100 6G    6)   ?? *	BuyCourse+6G   	  5?      $	 100 6H    6)   ?? *
SaleCourse+6H   5?      5?      5?      5?      