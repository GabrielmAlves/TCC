   M S B A M L   `   `   `  ����O  KPlayerClassifier.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PlayerClassifier.WPF.ViewPlayerClassifier.WPF.View  5      O,clr-namespace:PlayerClassifier.WPF.ViewModelPlayerClassifier.WPF.ViewModel  5      E'clr-namespace:PlayerClassifier.WPF.ViewPlayerClassifier.WPF.View  5      Q-clr-namespace:PlayerClassifier.WPF.ConvertersPlayerClassifier.WPF.Converters  5	      +    %PlayerClassifier.WPF.View.ProfileView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:PlayerClassifier.WPF.View     5      C
viewModels,clr-namespace:PlayerClassifier.WPF.ViewModel     5      9views'clr-namespace:PlayerClassifier.WPF.View     5      D
converters-clr-namespace:PlayerClassifier.WPF.Converters     5	      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fIfontA=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5
        � 	Resources  5      E   ?PlayerClassifier.WPF.Converters.ByteArrayToImageSourceConverter   ByteArrayToImageConverter��%   &	          5   
   65   5      .��5      �  � DataContext 5   
   5   /PlayerClassifier.WPF.ViewModel.ProfileViewModel  5      .+�5   
   ��  �� CornerRadius$ 10��6   
������ $��3q�5      ��5      �� 5       �� 
StartPoint$	 0,1&�6&    �� EndPoint$	 1,1&�67   .��5      �   primaryBackColor2 � Color# [ 6#    � Offset$ 0Q�6N   � 5      # [ 6#   $	 0.5Q�6N   � 5      # [ 6#   $	 0.5Q�6N   5      ._�5       � .+�5!      �  � RowDefinitions 5"      �� 5#      $��0 �6(   �� 5$      $��* �6(   .+�5&      �� $	��300��6!   $��1��5'       �� Orientation$ Vertical=�5(      $��50,10,70,-2q�5)      $��LeftToRight=�5*      $��Center=�5+      .+�5,      A� $��95��6"   $��95��6.   ���#000$��2��5.      $��	10,0,10,0q�5/      ��50      �� 51   "   -   5        	imageName��	 �� ImageSource	 51   @   �� *ProfilePicture+
 �� 	Converter#
 [  53      �� 54      -   5         ��Name$ btnLogin��54   !   $��0q�55   !   $��Escolha uma foto��56   !   
�������$��12(�58   !   $��
Montserrat)�59   !    � Cursor$
 Hand��5:   !   $��3��5;   !   $��0,15,0,0q�5<   !   ��5>      �� 5?   "    �� 
TargetType" ��6(   .�5@   &   ��  �� Property � �� �� Value
 �   �6C    �� Triggers 5A   &   P� 5B   *    P� Property �@J�IsMouseOver P� Value$
 True��6I   . �5C   .   ��  � ��
 � � �6K   5D   +   5F   #   ��5I      �� 5J   "    �� 
TargetType" ��62   .R�5K   &   �� $	��150��6-   $��40��69   $ 20��6E   #��z��6W   ._�5L   *   �� $��Center=�6;   $��Center=�5M   -   5N   '   5O   #   5Q      �� 5S      $��Cargo��6$   
���   �$��12(�5U   !   $��Medium"�5V   !   $��Suez One)�5W   !   $
��Left=�5X   !   $��0,15,0,0q�5Y   !   �� 5[      -   5         ��Name$ txtCargo��5[   "   $��13(�5]   "   
������ $��Medium"�5_   "   
���   � �� 
CaretBrush
 �����
�������$��0,0,0,1q�5c   "   $��28��5d   "   $��Center=�5e   "   $��0,5,0,0q�5f   "   ��5\   "   �� *	UserCargo+ �� UpdateSourceTrigger$ PropertyChanged=�{�5g   "   �� *IsTextBoxEnabled+.��6I   5h      �� 5i      -   5        $ btnEditCargo��5i   "   $
��Auto��5k   "   $
��Auto��5l   "   $��Right=�5m   "   $��	0,-35,0,0q�5n   "   
������ .��5p      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Pencil=�6.   $��20��5q   "   $��20��5r   "     iconButtonIcon#��[ 5s   "   $��LeftToRight=�5t   "   5u      �� 5w      -   5        $ btnSaveChanges��5w   !   $��0q�5x   !   $��Salvar alterações��5y   !   
�������$��12(�5{   !   $��
Montserrat)�5|   !   $
 Hand��5}   !   $��3��5~   !   $��0,65,0,0q�5   !   ��5�   !   �� *SaveChangesCommand+��5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��
 � � �6C    5�   &   P� 5�   *    �@J�IsMouseOver$
 True��6I   . �5�   .   ��  � ��
 � � �6K   5�   +   5�   #   ��5�      �� 5�   "   " ��62   .R�5�   &   �� $	��150��6-   $��40��69   $ 20��6E   #��z��6W   ._�5�   *   �� $��Center=�6;   $��Center=�5�   -   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      