   M S B A M L   `   `   `  ����H  DHoWestPost.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HoWestPost.UIHoWestPost.UI  5   	       HoWestPost.UI.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:HoWestPost.UI     5   	   X TXceed.Wpf.Toolkit, Version=3.7.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  HoWest Post��5	   	   $	��450��6   $	��800��6*   .��5
      � .+�5   
   �� $
��Left=�6   $��23��6/   $��	62,42,0,0q�6;   $
��Wrap=�6N   $��Pakket versturen��6b   $	��Top=�6z   $	��120��6�   $��Arial)�6�   $
��Bold"�6�   $��14(�6�   �� 5   
   $��Center=�6   $��23��61   $��335,42,335,354q�6=   $
��Wrap=�6U   $��In behandeling��6i   $��Center=�6   $	��122��6�   $��Arial)�6�   $
��Bold"�6�   $��14(�6�    �� TextAlignment$ Center=�6�   ��6�   Z� �� 5   
   $��Center=�6   $��23��61   $��578,42,92,354q�6=   $
��Wrap=�6T   $��Onderweg��6h   $��Center=�6x   $	��122��6�   $��Arial)�6�   $
��Bold"�6�   $��14(�6�   $ Center=�6�   ��6�   Z� �� 5   
   $
��Left=�6   $��23��6/   $��	10,98,0,0q�6;   $
��Wrap=�6N   $��Reistijd��6b   $	��Top=�6r   $	��120��6�   $��Arial)�6�   $��14(�6�   �� 5   
   -   5         ��Name$ chkPriority��5      $��Prioriteit?��6(   $
��Left=�6>   $��101,150,0,0q�6Y   $	��Top=�6n   #  Xceed.Wpf.Toolkit.ULongUpDown  5   
   -   5          Name$ nNumberTraveltime��5   W   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 30X�6      Maximum$ 90X�6&      Minimum$ 30X�63   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   AllowTextInput .  $
��Left=�6r   $��
101,98,0,0q�6�   $	��Top=�6�   $	��163��6�   $��23��6�   �� 5   
   -   5         ��Name$ btnSend��5      $��	Versturen��6"   $
��Left=�66   $��101,250,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   	� 5   
   -   5        	 	�Name$	 rbtnStandaard��5      
 d� 	IsChecked$

 TrueY�6-    	� 	GroupName$ PackageType��6>   $��	Standaard��6V   $
��Left=�6j   $��101,198,0,0q�6�   $	��Top=�6�   $��75��6�   6�   	� 5   
   -   5        $	 rbtnMini��5      $ PackageType��6(   $
��Mini��6@   $
��Left=�6O   $��
32,198,0,0q�6j   $	��Top=�6~   6�   	� 5   
   -   5        $	 rbtnMaxi��5      $ PackageType��6(   $
��Maxi��6@   $
��Left=�6O   $��205,198,0,0q�6j   $	��Top=�6   6�   �� 5   
   -   5         ��Name$ txtInfo��5      $
��Left=�6%   $��559,102,0,0q�6@   $
��Wrap=�6U   $!��Er is geen pakket onderweg.��6i   $	��Top=�6�   $	��175��6�   $
��Bold"�6�   $ Center=�6�   �� 5   
   $
��Left=�6   $��23��6/   $��559,205,0,0q�6;   $
��Wrap=�6P   $��Totale reistijd��6d   $	��Top=�6{   $	��120��6�   $��Arial)�6�   $��14(�6�   �� 5   
   -	   5        $ txtTotalTraveltime��5      $
��Left=�60   $��23��6K   $��679,205,0,0q�6W   $
��Wrap=�6l   $	��Top=�6�   $	��103��6�   $��Arial)�6�   $��14(�6�   $
��Bold"�6�   �� 5   
   $
��Left=�6   $��23��6/   $��559,247,0,0q�6;   $
��Wrap=�6P   $��Pakket type��6d   $	��Top=�6w   $	��120��6�   $��Arial)�6�   $��14(�6�   �� 5   
   -
   5        $ txtPackageType��5      $
��Left=�6,   $��23��6G   $��679,247,0,0q�6S   $
��Wrap=�6h   $	��Top=�6|   $	��103��6�   $��Arial)�6�   $��14(�6�   $
��Bold"�6�   �� 5    
   $
��Left=�6   $��23��6/   $��559,287,0,0q�6;   $
��Wrap=�6P   $	��Top=�6d   $	��120��6|   $��Arial)�6�   $��14(�6�   �� 6�   $�Prior��6�   �� 6�   $�iteit��6�   �� 6�   $�?��6�   6�   �� 5!   
   -   5        $ txtPriorOrNot��5!      $
��Left=�6+   $��23��6F   $��679,287,0,0q�6R   $
��Wrap=�6g   $	��Top=�6{   $	��103��6�   $��Arial)�6�   $��14(�6�   $
��Bold"�6�   �� 5"   
   $
��Left=�6   $��23��6/   $��559,324,0,0q�6;   $
��Wrap=�6P   $��	Resterend��6d   $	��Top=�6u   $	��120��6�   $��Arial)�6�   $��14(�6�   �� 5#   
   -   5        $ txtRestingTime��5#      $
��Left=�6,   $��23��6G   $��679,324,0,0q�6S   $
��Wrap=�6h   $	��Top=�6|   $	��103��6�   $��Arial)�6�   $��14(�6�   $
��Bold"�6�   �� 5$   
   $
��Left=�6   $��23��6/   $��559,365,0,0q�6;   $
��Wrap=�6P   $��
Huidige ID��6d   $	��Top=�6v   $	��120��6�   $��Arial)�6�   $��14(�6�   �� 5%   
   -   5        $ txtDeliveryId��5%      $
��Left=�6+   $��23��6F   $��679,365,0,0q�6R   $
��Wrap=�6g   $	��Top=�6{   $	��103��6�   $��Arial)�6�   $��14(�6�   $
��Bold"�6�   � 5&   
   -   5         �Name$ progressBar��5&      $
��Left=�6,   $��24��6G   $��559,150,0,0q�6S   $	��Top=�6h   $	��175��6�   �� 5)   
   -   5         ��Name$ lstDeliveries��5)      $
��Left=�6)   $	��290��6D   $��
284,98,0,0q�6Q   $	��Top=�6e   $	��256��6}   5+      5,      