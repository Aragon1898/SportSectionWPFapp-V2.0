   M S B A M L   `   `   `  ����K  GSportSectionWPF2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SportSectionWPF2SportSectionWPF2  5   	   !    SportSectionWPF2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SportSectionWPF2     5   	     � Title$  Авторизация��5      $	��160��6%   $	��400��62    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $&�� Имя пользователя:��5      $��0,0,5,0q�5      $��Center=�5      $��26��6+   �� 5   
   -   5         ��Name$ UserNameTextBox��5      $��0��5      $��
119,5,0,10q�5      $��0��5      $��2��6   �� 5!   
   $��1��6   $��0��6   $��Пароль:��5"      $��0,0,5,0q�5#      $��Center=�5$      $��26��6+   G� 5%   
   -   5         G�Name$ PasswordTextBox��5&      $��1��5%      $��
119,5,0,10q�5'      $��1��5(      $��2��6#   �� 5,   
   -   5        $��2��5-      $��1��6   $��Вход��5.      $	��100��5/      $
��Left=�50      $��2��51      $��21,6,0,5q�6   56      57      