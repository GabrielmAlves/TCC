   M S B A M L   `   `   `  ����O  KPlayerClassifier.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:PlayerClassifier.WPF.ViewModelPlayerClassifier.WPF.ViewModel  5      E'clr-namespace:PlayerClassifier.WPF.ViewPlayerClassifier.WPF.View  5      +    %PlayerClassifier.WPF.View.CompareView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fOfontAwesome=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      <	viewModel,clr-namespace:PlayerClassifier.WPF.ViewModel  5      3local'clr-namespace:PlayerClassifier.WPF.View  5      .��5      �   � DataContext  5   
   5   /PlayerClassifier.WPF.ViewModel.CompareViewModel  5      .+�5   
   ��  �� CornerRadius$ 10��6   
������ $��3q�5   	   ��5      �� 5       �� 
StartPoint$	 0,1&�6&    �� EndPoint$	 1,1&�67   .��5      �    primaryBackColor2 � Color# [  6#    � Offset$ 0Q�6N   � 5      # [  6#   $	 0.5Q�6N   � 5      # [  6#   $	 0.5Q�6N   5      ._�5      � .+�5      �  � RowDefinitions 5      �� 5      $��0 �6(   �� 5      $��* �6(   .+�5!      �� $	��300��6!   $��1��5"       �� Orientation$ Vertical=�5#      $��50,-30,70,-2q�5$      $��LeftToRight=�5%      $��Center=�5&      .+�5'      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ 
FileUpload=�60   $	��100��5(   (   $	��100��5)   (   $��Center=�5*   (   $��Center=�5+   (   $��0,60,0,0q�5,   (   �� 5-      $��Center=�6%   $��Center=�5.      .+�5/      �� -   5        	 ��Name$	 btnUploadFile1��5/   %   $��0q�50      $��Envie arquivos .csv��51      
�������$��12(�53      $��
Montserrat)�54      
 � Cursor$

 Hand��55      $��3��56      $��0,35,0,0q�57      ��59   "   �� 5:   &    �� 
TargetType" ��6,   .�5;   *   ��  �� Property � �� �� Value
 � � �6G    �� Triggers 5<   *   P� 5=   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �5>   2   ��  � ��
 � � �6O   5?   /   5A   '   ��5D   "   �� 5E   &    �� 
TargetType" ��66   .R�5F   *   �� $	��150��61   $��40��6=   $ 20��6I   #��z��6[   ._�5G   .   �� $��Center=�6?   $��Center=�5H   7   5I   +   5J   '   5L      5M      �� 5N      .+�5O      �� -   5        $	 
btnCompare��5O   %   $��0q�5P      $��Comparar jogadores��5Q      
�������$��12(�5T      $��
Montserrat)�5U      $

 Hand��5V      $��3��5W      $��0,35,0,0q�5X      ��5R      �� *CompareCommand+��5Y   "   �� 5Z   &   " ��6,   .�5[   *   ��  � �� �#0006G    5\   *   P� 5]   .    �@J�IsMouseOver$
 True��6M   . �5^   2   ��  � �� �#0006O   5_   /   5a   '   ��5d   "   �� 5e   &   " ��66   .R�5f   *   �� $	��150��61   $��40��6=   $ 20��6I   #��z��6[   ._�5g   .   �� $��Center=�6?   $��Center=�5h   )   5i   +   5j   '   5l      5m      5n      5o      5p      5q      5r      5s      