   M S B A M L   `   `   `  ����K  GSportSectionWPF2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:SportSectionWPF2.View.WindowsSportSectionWPF2.View.Windows  5   	   /    )SportSectionWPF2.View.Windows.CoachWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:SportSectionWPF2.View.Windows     5   	     � Title$  CoachWindow��5   	   $	��450��6   $	��800��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��293 �6   �� 5      .+�5   
   ]� $��0��6   $��10,10,10,10q�6$   .+�5      �� $	��Top=�6   $��0,0,0,10q�6.   .+�5      �� $ ��Список секций:��6   $
��Bold"�5      $��0,0,0,5q�5      5      �� 5      -   5         ��Name$ SectionsList��5       �� DisplayMemberPath$
 Name��5      $��0q�5      5      5      �� 5!   
   $��1��6   $��10,10,10,10q�5"   
    �� Padding$ 15q�5#   
   ���#DDDDDD$��1q�5%   
   ._�5'      �  � DataContext 6   �� *SelectedItem+ �� ElementName$ SectionsList�� � RowDefinitions 5(      �� 5)      $
��Auto �6$   �� 5*      $
��Auto �6$   �� 5+      $��* �6$   .+�5/      �� $��0��6   $��0,0,0,15q�6*   .+�50      ]� .+�51      �� -   5        $��SchedualLabel��51       $*��$Расписание занятий:��52       $��SemiBold"�53      $��0,0,0,5q�54      $
��Left=�55      �� 57       �� Orientation$ 
Horizontal=�6%   $��Right=�58      $��Right=�59      .+�5<      �� -   5        $��Изменить��5<   %   $��80��5=   %   $	��5,0q�5>   %   ���#2196F3
�������5A   %   �� 5C      -   5        $��Удалить��5C   %   $��80��5D   %   ���	#FFF44336
�������5G   %   5H      5I      �� 5K      $��14(�5L      ��5K       �� *Schedule.DaysOfWeek+5L      5M      �� 5P      $��1��6   .+�5Q      ]� $��0,0,0,10q�6    .+�5R      �� $&�� Участники секции:��6    $��SemiBold"�5S      $��0,0,0,5q�5T      $
��Left=�5U      �� 5W      $ 
Horizontal=�6%   $��Right=�5X      $��Right=�5Y      .+�5Z      �� -   5        $>��8Отметить успеваемость ученика��5Z   %   $	��190��5[      $	��5,0q�5\      ���	#FF4CAF50
�������5_   %   5`      5a      �� 5c      $��3��6!   .+�5d      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 MembersDataGrid��5d   #   
   AutoGenerateColumns
 .     CanUserAddRows .  $
��0,25q�5e         Columns 5f      0  *System.Windows.Controls.DataGridTextColumn  5g   "   ,  &System.Windows.Controls.DataGridColumn   Header$ ID��65      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Id+6X     5h   "   $ Имя(логин)��65   $ * 6g    6I   �� *	User.Name+6g     5i   "   $ Пароль��65   $ * 6g    6E   �� *User.Password+6g   5k      5l      �� 5n      ��6#   �� *	Members+��5o      �� 5p      .R�5q   "   �� $	��0,5q�6)   $ 10q�5r   "   ���#EEEEEE$��0,0,0,1q�5t   "   ._�5u   &   �� .+�5w   *   ]� .+�5x   .   �� $��14(�5y   -   $��0,0,0,5q�5z   -   $��DemiBold"�5{   -   $
��Left=�5|   -   ��5x   4   �� *
FullName+5|   -   �� 5~   .   $ 
Horizontal=�69   $��Right=�5   1   $��Right=�5�   1   .+�5�   2   �� $��Изменить��69   $��70��5�   2   $��2q�5�   2   ���#2196F3
�������5�   2   �� 5�   2   $��Удалить��69   $��70��5�   2   $��2q�5�   2   ���	#FFF44336
�������5�   2   5�   /   5�   +   �� 5�   *   $.��(История посещаемости:��60   $��0,5,0,2q�5�   )   ���#6666665�   )   9� 5�   *    9� 
IsExpanded .  $	��0,5q�5�   ,   5�   +   �� 5�   *   $(��"Список достижений:��60   $��0,10,0,2q�5�   )   ���#6666665�   )   9� 5�   *    .  $	��0,5q�5�   ,   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      