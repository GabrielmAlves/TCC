   M S B A M L   `   `   `  ����O  KPlayerClassifier.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PlayerClassifier.WPF.ViewPlayerClassifier.WPF.View  5   	   Y1clr-namespace:PlayerClassifier.WPF.CustomControls#PlayerClassifier.WPF.CustomControls  5   	   O,clr-namespace:PlayerClassifier.WPF.ViewModelPlayerClassifier.WPF.ViewModel  5   	   2    ,PlayerClassifier.WPF.View.ForgotPasswordView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:PlayerClassifier.WPF.View     5   	   Lcustomcontrols1clr-namespace:PlayerClassifier.WPF.CustomControls     5   	   B	viewModel,clr-namespace:PlayerClassifier.WPF.ViewModel     5   	   -   5          � WindowStyle$
  None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency$
 True��5   	    � Title$ ForgotPasswordView��5   	   $	��650��6$   $	��800��61    � DataContext 5      <   6PlayerClassifier.WPF.ViewModel.ForgotPasswordViewModel  5   
    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6'   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'   	 �� 	Converter#	 [  65   .��5      � .+�5   
   �� 
 �� CornerRadius$
 50��6   
�������$��3q�5!   	   ��5"      �� 5#       �� 
StartPoint$	 0,1&�6&    �� EndPoint$	 1,1&�67   .��5$      �  � Color$ #10801D��6#    � Offset$ 0Q�63   � 5%      $ #10801D��6#   $	 0.5Q�63   � 5&      $
 #FFF��6#   $	 0.5Q�60   5'      ._�5*      �  � RowDefinitions 5+      �� 5,      $��30 �6$   �� 5-      .+�50      �  � ColumnDefinitions 51      �� 52      $
��139* �6+   �� 53      $
��231* �6+   �� 54      $��25 �6+   �� 55      $��30 �6+   �� 56      $��20 �6+   .+�59      �� $�� ��6    ���#fff$��20(�5;      $��
Montserrat)�5<      $��0��5=      $��Center=�5>      $��30,0,0,0q�5?      $��24��6*   $��2��66   �� 5A      -   5         ��Name$ btnMinimize��5A      $��0q�5B      $��-��5C      
�������$��16(�5E      $��
Montserrat)�5F       � Cursor$
 Hand��5G      $��2��5H      ��5J      �� 5K       �� 
TargetType" ��6$   .�5L   "   ��  �� Property � �� �� Value
 �   �6?    �� Triggers 5M   "   P� 5N   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5O   *   ��  � ��
 �   �6G   5P   '   5R      ��5U      �� 5V       �� 
TargetType" ��6.   .R�5W   "   �� $��18��6)   $��18��64   $
 9��6@   #��z��6Q   ._�5X   &   �� $��Center=�67   $��Center=�5Y      5Z   #   5[      5]      �� 5_      -   5        $ btnClose��5_      $��0q�5`      $��X��5a      
�������$��12(�5c      $��
Montserrat)�5d      $
 Hand��5e      $��3��5f      $��0,0,6,0q�5g   0   ��5i      �� 5j      " ��6$   .�5k   "   ��  � ��
 �  ��6?    5l   "   P� 5m   &    �@J�IsMouseOver$
 True��6E   . �5n   *   ��  � ��
 �  ��6G   5o   '   5q      ��5t      �� 5u      " ��6.   .R�5v   "   �� $��18��6)   $��18��64   $
 9��6@   #��z��6Q   ._�5w   &   �� $��Center=�67   $��Center=�5x      5y   #   5z      5|      5}      �� 5      $	��250��6   $��2��5�       �� Orientation$ Vertical=�5�      $��
400,35,0,0q�5�      .+�5�      �� $��/Images/pc-image.png��6   $	��100��5�      $	��100��6!   �� 5�      $��Recupere sua senha��6    
���   �$��25(�5�      $��Medium"�5�      $��Center=�5�      �� 5�      $��Nome de usuário��6    
���   �$��12(�5�      $��Medium"�5�      $��Suez One)�5�      $
��Left=�5�      $��0,25,0,0q�5�      �� 5�      -   5         ��Name$ txtUserName��5�      $��13(�5�      
������ $��Medium"�5�      
���   � �� 
CaretBrush
 �����
�������$��0,0,0,1q�5�      $��28��5�      $��Center=�5�      $��0,5,0,0q�5�      ��5�      �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=�.��5�   '   5�      �� 5�      $��
Nova senha��6    
���   �$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $
��Left=�5�      $��0,15,0,0q�5�      =   7PlayerClassifier.WPF.CustomControls.BindablePasswordBox  5�      $��28��5�      $��0,5,0,0q�5�         Password 5�      �� *NewPassword+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      .+�5�      �� ���#D75960$��12(�5�      $��Medium"�5�      $��Suez One)�5�      $��0,5,0,0q�5�      $
��Wrap=�5�      ��5�   $   �� *ErrorMessage+5�      �� 5�      -   5        $ btnConfirmarSenha��5�   !   $��0q�5�      $��Confirmar nova senha��5�      
�������$��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��3��5�      $��0,10,0,0q�5�      ��5�      �� *ConfirmPasswordCommand+��5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��
 �   �6C    5�   &   P� 5�   *    �@J�IsMouseOver$
 True��6I   . �5�   .   ��  � ��
 �   �6K   5�   +   5�   #   ��5�      �� 5�   "   " ��62   .R�5�   &   �� $	��150��6-   $��40��69   $
 20��6E   #��z��6W   ._�5�   *   �� $��Center=�6;   $��Center=�5�      5�   '   5�   #   5�      5�      5�      �� 5�      $	��490��6   $��2��5�      $ Vertical=�5�      $��-600,10,-95,30q�5�      .+�5�      �� $"��/Images/soccer-field (1).png��6   $	��536��5�      $	��497��6    J� RenderTransformOrigin$ 0.477,0.848&�6*   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "     �� Angle$  89.795Q�62   T� 5�   "   ! T� X$! -81.481Q�65   " T� Y$" -80.023Q�6A   5�      5�      5�      5�      5�      5�      5�      