   M S B A M L   `   `   `  ����O  KPlayerClassifier.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PlayerClassifier.WPF.ViewPlayerClassifier.WPF.View  5      O,clr-namespace:PlayerClassifier.WPF.ViewModelPlayerClassifier.WPF.ViewModel  5      /    )PlayerClassifier.WPF.View.ObservationView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:PlayerClassifier.WPF.View     5      B	viewModel,clr-namespace:PlayerClassifier.WPF.ViewModel     5      .��5
      �   � DataContext  5   
   9   3PlayerClassifier.WPF.ViewModel.ObservationViewModel  5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $(��"Nenhum jogador em observação! :(��6   $��Center=�5      $��Center=�6)   $��16(�6D   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � y� �� Value$ 	Collapsed=�63    �� Triggers 5      �� 5       �� Binding 6&   �� *
IsOnHold+ �� Value	 False6C   .a�5      ��  � y�$ Visible=�6;   5      5      5       &   System.Windows.Controls.DataGrid  5"   
   $��1��6      AutoGenerateColumns$ False��5#      $��Stretch=�6'   $��Stretch=�6E   $��10q�6a   	   AlternatingRowBackground	 �#E8F5E9
   HeadersVisibility$
 Column=�5%         GridLinesVisibility$ 
Horizontal=�5&       �� AlternationCount$ 2��5'      ��5"       �� *PlayersOnHold+��5(      �� 5)      "  6   .�5*      ��  � ��
 �����63   �� 5+       � ��
 �   �63   �� 5,       �@ GridLinesVisibility$ 
Horizontal=�6<   �� 5-       �@ ColumnHeaderHeight$ 40Q�6;   �� 5.       �@ 	RowHeight$ 35Q�62   �� 5/        �@ HorizontalGridLinesBrush �#10801D6A   �� 50       �@ VerticalGridLinesBrush
 ���� 6?    51      �� 52       6&   �� *HasClassifications+ True6M   .a�53      ��  � y�$ Visible=�6;   54      56       � 	Resources 58      =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell �� 
TargetType �� CornerRadius �� Padding)  #System.Windows.Controls.DataGridRow P� Property P� Value��%�  '        '  �     '  �    �� 5:      "  6   .�5;      ��  � �� �#10801D63   �� 5<       � ��
 �����63   �� 5=       � ��$
 Bold"�63   �� 5>       � ��$ Center=�6C   �� 5?       � ��$ 10q�60   5@      �� 5C      "  6   .�5D      ��  � �� 5E      �� 5F      "  6.   .R�5G   "   �� #��z��6)   #��z��5H   !   $��1q�5I   !   $ 10��5J   !   $ 5q�5K   !   ._�5L   &   �� $��Center=�67   $��Center=�6T   5M   #   5N      5P      5Q      �� 5T      "  6   .�5U      ��  � ��
 �����63   �� 5V       � ��$ Stretch=�6<   �� 5W       � ��$ Stretch=�6:    5X      P� 5Y       �@��AlternationIndex$ 1��6K   . �5Z      ��  � �� �#E8F5E96;   5[      P� 5\       �@ 
IsSelected$
 True��68   . �5]      ��  � �� �#10801D6;   �� 5^       � ��
 �����6;   5_      5a      5b         Columns 5c      0  *System.Windows.Controls.DataGridTextColumn  5d      ,  &System.Windows.Controls.DataGridColumn   Header$
 Nome��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+  5e      $ ID��6%    61   �� *
PlayerId+  5f      $ Sobre��6%    64   �� *About+5h      5i      5j      