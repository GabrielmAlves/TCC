   M S B A M L   `   `   `  ����O  KPlayerClassifier.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PlayerClassifier.WPF.ViewPlayerClassifier.WPF.View  5   	   E'clr-namespace:PlayerClassifier.WPF.ViewPlayerClassifier.WPF.View  5   	   O,clr-namespace:PlayerClassifier.WPF.ViewModelPlayerClassifier.WPF.ViewModel  5   	   Y1clr-namespace:PlayerClassifier.WPF.CustomControls#PlayerClassifier.WPF.CustomControls  5	   	   )    #PlayerClassifier.WPF.View.LoginView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:PlayerClassifier.WPF.View     5   	   8view'clr-namespace:PlayerClassifier.WPF.View     5   	   B	viewModel,clr-namespace:PlayerClassifier.WPF.ViewModel     5   	   Lcustomcontrols1clr-namespace:PlayerClassifier.WPF.CustomControls     5	   	   -   5          � Title$  Login��5   	   $	��550��6   $	��800��6$    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency$
 True��5   	    � DataContext 5      3   -PlayerClassifier.WPF.ViewModel.LoginViewModel  5   
    � 	Resources 5         BooleanToVisibility  NoHoverButtonStyle �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� Padding��%M  &	        &	      �� 5   
   6'   �� 5   
   " ��6+   .�5      ��  � ��
	 ���� 6+   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5    !   # z��5!   !   ._�5"      �� $��Center=�6/   $��Center=�5#   /   5$      5%      5'      5(      5-      y�5/      �� 50   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'    �� 	Converter# [  65   .��56      ��  �� CornerRadius$ 50��6   
�������$��3q�58      ��59   
   �� 5:       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,1&�63   .��5;      �   primaryBackColor1 � Color# [ 6    � Offset$ 0Q�6J   � 5<      # [ 6   $	 0.5Q�6J   � 5=        primaryBackColor2# [ 6   $	 0.5Q�6J   5>      ._�5A   
   �  � RowDefinitions 5B      �� 5C      $��30 �6    �� 5D      .+�5G      �  � ColumnDefinitions 5H      �� 5I      $
��139* �6'   �� 5J      $
��231* �6'   �� 5K      $��25 �6'   �� 5L      $��30 �6'   �� 5M      $��20 �6'   .+�5P      �� $�� ��6   ���#fff$��20(�5R      $��
Montserrat)�5S      $��0��5T      $��Center=�5U      $��30,0,0,0q�5V      $��24��6.   $��2��6:   �� 5X      -   5         ��Name$ btnMinimize��5X      $��0q�5Y      $��-��5Z      
�������$��16(�5\      $��
Montserrat)�5]       � Cursor$
 Hand��5^      $��2��5_      ��5a      �� 5b      " ��6    .�5c      ��  � ��
	 �   �6;    �� Triggers 5d      P� 5e   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5f   &   ��  � ��
	 �   �6C   5g   #   5i      ��5l      �� 5m      "
 ��6*   .R�5n      �� $��18��6%   $��18��60   $ 9��6<   #��z��6M   ._�5o   "   �� $��Center=�63   $��Center=�5p   3   5q      5r      5t      �� 5v      -   5        $ btnClose��5v      $��0q�5w      $��X��5x      
�������$��12(�5z      $��
Montserrat)�5{      $
 Hand��5|      $��3��5}      $��0,0,6,0q�5~   0   ��5�      �� 5�      " ��6    .�5�      ��  � ��
	 �  ��6;    5�      P� 5�   "    �@J�IsMouseOver$
 True��6A   . �5�   &   ��  � ��
	 �  ��6C   5�   #   5�      ��5�      �� 5�      "
 ��6*   .R�5�      �� $��18��6%   $��18��60   $ 9��6<   #��z��6M   ._�5�   "   �� $��Center=�63   $��Center=�5�      5�      5�      5�      5�      �� 5�      $	��250��6   $��2��5�       �� Orientation$ Vertical=�5�      $��
400,35,0,0q�5�      .+�5�      �� $��/Images/pc-image.png��6   $	��100��5�      $	��100��6$   �� 5�      $��Player Classifier��6   
���   �$��25(�5�      $��Medium"�5�      $��Center=�5�      �� 5�      $��Nome de usuário��6   
���   �$��12(�5�      $��Medium"�5�      $��Suez One)�5�      $
��Left=�5�      $��0,25,0,0q�5�      �� 5�      -   5         ��Name$ txtUserName��5�      $��13(�5�      
������ $��Medium"�5�      
���   � �� 
CaretBrush
 �����
�������$��0,0,0,1q�5�      $��28��5�      $��Center=�5�      $��0,5,0,0q�5�      ��5�      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�.��5�   ,   5�      �� 5�      $��Senha��6   
���   �$��12(�5�      $��Medium"�5�      $��Suez One)�5�      $
��Left=�5�      $��0,15,0,0q�5�      =   7PlayerClassifier.WPF.CustomControls.BindablePasswordBox  5�      $��28��5�      $��0,5,0,0q�5�         Password 5�      �� *
Password+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $ 
Horizontal=�6   $��Right=�5�      $��0,10,0,0q�5�      .+�5�      �� -   5        $ btnEsqueceuSuaSenha��5�      $��Esqueceu sua senha?��5�      
�������$��12(�5�      $��
Montserrat)�5�      $��Medium"�5�      $
 Hand��5�      
���   �
������ #��[ 5�      ��5�      �� *RecoverPasswordCommand+5�      5�      �� 5�      $ 
Horizontal=�6   $
��Left=�5�      $��10,0,0,0q�5�      .+�5�      �� -   5          ��Name$  checkbox��5�      $��Lembrar de mim��61   ! d� 	IsChecked$! FalseY�6J   6�   5�      �� 5�      ���#D75960$��12(�5�      $��Medium"�5�      $��Suez One)�5�      $��0,10,0,0q�5�      $
��Wrap=�5�      ��5�      �� *ErrorMessage+5�      �� 5�      -   5        $ btnLogin��5�      $��0q�5�      $��Login��5�      
�������$��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��3��5�      $��0,50,0,0q�5�      ��5�      �� *LoginCommand+��5�      �� 5�      " ��6    .�5�      ��  � ��
	 �   �6;    5�      P� 5�   "    �@J�IsMouseOver$
 True��6A   . �5�   &   ��  � ��
	 �   �6C   5�   #   5�      ��5      �� 5     "
 ��6*   .R�5     �� $	��150��6%   $��40��61   $ 20��6=   #��z��6O   ._�5  "   �� $��Center=�63   $��Center=�5  3   5     5     5     �� 5
     $ 
Horizontal=�6   $��Center=�5     $��0,15,0,0q�5     .+�5     �� $��Não tem uma conta?��6    
���   �$��12(�5     $��Medium"�5     $��Suez One)�5     �� 5     $ 
horizontal=�6!   $��Center=�5  !   $��0,-2,0,0q�5  !   .+�5     �� -   5        $ btnRegistrar��5  !   $��	Registrar��5     
�������$��12(�5     $��
Montserrat)�5     $
��Bold"�5     $
 Hand��5     
���   �
������ #��[ 5      ��5     �� *DontHaveAccountCommand+5!     5"     5#     5$     �� 5&     $	��490��6   $��2��5'     $ Vertical=�5(     $��-600,10,-95,30q�5)     .+�5*     �� $"��/Images/soccer-field (1).png��6   $	��536��5+     $	��497��6%   " J� RenderTransformOrigin$" 0.477,0.848&�62   z�5,     V� 5-     .~�5.     �� �� 5/     �� 50     # �� Angle$# 89.795Q�6.   T� 51     $ T� X$$ -81.481Q�61   % T� Y$% -127.023Q�6=   52     54     55     59     5=     5@     