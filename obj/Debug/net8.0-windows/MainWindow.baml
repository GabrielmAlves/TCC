   M S B A M L   `   `   `  ����O  KPlayerClassifier.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PlayerClassifier.WPFPlayerClassifier.WPF  5   	   O,clr-namespace:PlayerClassifier.WPF.ViewModelPlayerClassifier.WPF.ViewModel  5   	   E'clr-namespace:PlayerClassifier.WPF.ViewPlayerClassifier.WPF.View  5   	   %    PlayerClassifier.WPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:PlayerClassifier.WPF     5   	   C
viewmodels,clr-namespace:PlayerClassifier.WPF.ViewModel     5   	   8view'clr-namespace:PlayerClassifier.WPF.View     5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fIfonta=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5	   	   -   5          � Title$  Player Classifier��5   	   $	��480��6#   $	��800��60    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      2   ,PlayerClassifier.WPF.ViewModel.MainViewModel  5   
    � 	Resources 5       �� DataType2   ,PlayerClassifier.WPF.ViewModel.HomeViewModel(   "PlayerClassifier.WPF.View.HomeView<   6PlayerClassifier.WPF.ViewModel.ClassifyPlayerViewModel,   &PlayerClassifier.WPF.View.ClassifyView5   /PlayerClassifier.WPF.ViewModel.HistoryViewModel+   %PlayerClassifier.WPF.View.HistoryView9   3PlayerClassifier.WPF.ViewModel.ObservationViewModel/	   )PlayerClassifier.WPF.View.ObservationView5
   /PlayerClassifier.WPF.ViewModel.ProfileViewModel+   %PlayerClassifier.WPF.View.ProfileView��%w  (��       5      *, +)(�� 2     5      *, +)(�� d     5#      *, +)(�� �     5'      *, +)(�� �     5+      *,
 +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5#   
   "  6   .R�5$        5%      �� 5'   
   "  6   .R�5(      	  5)      �� 5+   
   " 
 6   .R�5,        5-      5.      .��50      ��  �� CornerRadius$ 50��6   
�������$��3q�52   	   ._�55   
   �  � ColumnDefinitions 56      �� 57      $	��250 �6#   �� 58      $��* �6#   .+�5;      �� $ 	50,0,0,50��6   $��0��5<      ��5=      �� 5>      	 �� 
StartPoint$		 0,1&�6*   
 �� EndPoint$	
 1,1&�6;   .��5?      �    primaryBackColor1 � Color# [  6'    � Offset$ 1Q�6R   � 5@      # [  6'   $	 0.2Q�6R   � 5A        primaryBackColor2# [ 6'   $ 1Q�6R   5B      ._�5E      �� .+�5F      ��  �� Orientation$ 
Horizontal=�6!   $��75��5G   !   $��15,25,10,40q�5H   !   .+�5I      �� $��/Images/pc-image.png��6    $��80��6>   $��80��6J   �� 5J      $��Player Classifier��6$   ���#000$��20(�5L   $   $��
Montserrat)�5M   $   $��Medium"�5N   $   $��Center=�5O   $   $��0,0,0,0q�5P   $   5Q      �� 5S      $ 
Horizontal=�6!   $��25��5T   !   $��15,-55,10,0q�5U   !   5\      	� 5^        
menuButton#��[ 6"   
 � Tag# [  5_   "    d� 	IsChecked$
 TrueY�5`   "   ��5a   "   �� *ShowHomeViewCommand+.��5b      �� $ 
Horizontal=�6%   .+�5c      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6.     menuButtonIcon#��[ 6:   �� 5d      $
��Home��6(     menuButtonText#��[ 64   5e      5f      	� 5h      #��[ 6"   # [  5i   "   ��5j   "   �� *ShowClassifyViewCommand+.��5k      �� $ 
Horizontal=�6%   .+�5l        $ Futbol=�6.   #��[ 6<   �� 5m      $��Classificar��6(   #��[ 6;   5n      5o      	� 5z      #��[ 6"   # [  5{   "   ��5|   "   �� *ShowHistoryViewCommand+.��5}      �� $ 
Horizontal=�6%   .+�5~        $ ClockRotateLeft=�6.   #��[ 6E   �� 5      $��
Histórico��6(   #��[ 69   5�      5�      	� 5�      #��[ 6"   # [  5�   !   ��5�   "   �� *ShowObservationViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ 
Binoculars=�6.   #��[ 6@   �� 5�      $��Em observação��6(   #��[ 6=   5�      5�      5�      5�      �� 5�      $ 
00,50,50,0��6   $��1��5�      ��5�      �� 5�      $		 1,1&�6*   $	
 0,0&�6;   .��5�      � # [ 6'   $ 1Q�6R   5�      ._�5�      �  � RowDefinitions 5�      �� 5�      $��25 �6(   �� 5�      $��35 �6(   �� 5�      $��* �6(   .+�5�      �� -   5         ��Name$ pnlControlBar��5�   !   $��0��5�   !   $ 
Horizontal=�5�   !   $��RightToLeft=�5�   !   
������ $��0,0,30,0q�5�   !   .+�5�      �� -   5         ��Name$ btnClose��5�   !     controlButton#��[ 5�   !     primaryBackColor3# [ 5�   !   .��5�        $ Xmark=�6.     controlButtonIcon#��[ 6;   5�      �� 5�      -   5        $ btnMaximize��5�   !   #��[ 5�   !   # [  5�   !   .��5�        $ Square=�6.   #��[ 6<   5�      �� 5�      -   5        $ btnMinimize��5�   !   #��[ 5�   !   # [  5�   !   .��5�        $ WindowMinimize=�6.   #��[ 6D   5�      5�      � 5�      $��1��6    5�      �� 5�      �� 5�      .+�5�      �� $��0��6%   $ 
Horizontal=�5�   %   $��Center=�5�   %   .+�5�        $��20��5�   .   $��20��5�   .      
Foreground �#000$��	35,0,10,0q�5�   .    5�   .   �� *Icon+5�   .   �� 5�      ���#000$��16(�5�   (   $��
Montserrat)�5�   (   $��Medium"�5�   (   $��Center=�5�   (   ��5�   (   �� *ChildViewName+5�   (   5�      �� 5�      $��1��6%   $ 
Horizontal=�5�   %   $��RightToLeft=�5�   %   $��Center=�5�   %   $��0,0,10,0q�5�   %   .+�5�      ��   
iconButton#��[ 6%   # [  5�   %   .��5�   "   � .+�5�   &     -   5        $ 	AngleDown=�5�   6    	 iconButtonIcon#��[	 6g   $��12��6�   $��12��6�   � 5�   &   -   5         �Name$ popup��5�   ,    � AllowsTransparency$
 True��6;   $��Bottom=�6�    � PlacementTarget 6U   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" ��.��5�   *   o� 
������ $��0q�6H    5�   .    �� 
TargetType �� Property �� Value �� 
TargetType��%�  'm�       �� 5�   2   " m�68   .�5�   6   ��  � ��$ 16(�6Q   �� 5�   6    � �� �#FFF6S   �� 5�   6    � ��$ 10q�6P   �� 5�   6    � ��
 � � �6S   �� 5�   6    � �� 5�   :   �� 5�   >   " m�6N   .R�5�   B   �� #��z��6I   #��z��5�   =   #��z��5�   =   $ 20��5�   =   ._�5�   F   �� #��z��6W   #��z��5�   >   5�   C   5�   ?   5�   7   5�   3   5�   /   ��5   .   �� 5  2   .R�5  6   $�  $� Orientation$ Vertical=�6M   5  3   .@�5  .   m� -   5        $��Perfil��5  7    � Cursor$
 Hand��6^   $��Center=�6�     m� Command  6l   �� *ShowProfileViewCommand+6�   m� 5  .   -	   5        $
��Sair��5  7   $
 Hand��6E   $��Center=�6S   6p   5  +   5  '   5	  #   5
     �� 5     ���#000$��
Montserrat)�5  (   $��Medium"�5  (   $��12(�5  (   $��Center=�5  (   ��5  (   �� * CurrentUserAccount.displayName+5  (   A� 5     $��35��6&   $��35��62   ���#000$��2��5  &   $��	10,0,10,0q�5  &   ��5  "   �� 5  &   ! �� ImageSource$! /Images/pc-image.png��61   5     5     5     �� 5     $��2��5   %   $��25q�5!  %   ��5  %   �� *CurrentChildView+5!  %   5"     5#     5$     5%     5'     