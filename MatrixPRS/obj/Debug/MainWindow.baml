   M S B A M L   `   `   `  ����D  @MatrixPRS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MatrixPRS	MatrixPRS  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       MatrixPRS.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   #localclr-namespace:MatrixPRS  5   	   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	     � Title$  PRS 2021��5
   	   $��464.4��6   $	��984��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   .��5      � .+�5   
   � -   5         �Name$ 	sidePanel��5       K� ZIndex$ 2��6"   ���	#FF0F4E7A$
��Left=�6J   $	��150��6e   .+�5      �� .+�5      � $	��150��6   ���	#FF0F4E7A.+�5      �� -   5        $��Right=�5      $��20��69   $	��Top=�6E   
������ 
������ .��5      �� $��/icons/menu_32px.png��6    5      5      �� 5      $��Disabled=�6   $��Century Gothic)�6Q   $��14(�6m   
�������
������ 
������ $
��Bold"�6�   .@�5      �� $��30��6#   .��5      �� -   5         �� Orientation$ 
Horizontal=�5   %   .+�5      �� $��/icons/multiply_32px.png��6$   $��20��6F   $��Center=�6R   �� 5      $��15 0 0 0q�6(   $��	Množenje��6:   $��Center=�6J   5      5      �� 5      $��30��6#   .��5      �� -   5        $ 
Horizontal=�5   %   .+�5      �� $��/icons/plus_math_32px.png��6$   $��20��6G   $��Center=�6S   �� 5      $��15 0 0 0q�6(   $��	Sabiranje��6:   $��Center=�6K   5      5      �� 5       $��30��6#   .��5!      �� -   5        $ 
Horizontal=�5!   %   .+�5"      �� $#��/icons/select_invert_32px.png��6$   $��20��6K   $��Center=�6W   �� 5#      $��15 0 0 0q�6(   $��Invertovanje��6:   $��Center=�6N   5$      5%      �� 5&      $��30��6#   .��5'      �� -   5        $ 
Horizontal=�5'   %   .+�5(      �� $)��#/icons/delete_graph_report_32px.png��6$   $��20��6Q   $��Center=�6]   �� 5)      $��15 0 0 0q�6(   $��Obriši grafik��6:   $��Center=�6O   5*      5+      5,      5-      5.      #  LiveCharts.Wpf.CartesianChart  5/   
   -   5          Name$ chart��5/      $ 1��6,   $��0��6=   $��45 10 10 40q�6L   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6a      	Hoverable .  	   AxisX	 51        LiveCharts.Wpf.Axis  -   5        $��xAxis��51      
   Title$
 Velicine matrica ( NxN )��6(   6L      AxisY 54        $
 Proteklo vrijeme [ms]��6   6=   56      ]� 57   
   $��1��6   .+�58      �� $��Bottom=�6   $��Center=�64   $ 
Horizontal=�6Q   $
��Left=�6k   $��10q�6�   .+�59      �� $��Od��6   %  Xceed.Wpf.Toolkit.IntegerUpDown  5:      -	   5        $��numericDonji��5:   %   $	��100��69   $
��10,0q�6E   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 50X�6S      Minimum$ 3X�6^      Maximum$	 600X�6j   �� 5;      $��Do��6     5<      -
   5        $��numericGornji��5<   %   $	��100��6;   $
��10,0q�6G   $	 100X�6U   $	 900X�6a   $ 3X�6o   5=      5>      5?      5@      