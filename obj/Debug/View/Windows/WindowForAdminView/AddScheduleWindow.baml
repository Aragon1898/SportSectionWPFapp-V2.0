   M S B A M L   `   `   `  ����K  GSportSectionWPF2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:SportSectionWPF2.View.Windows.WindowForAdminView0SportSectionWPF2.View.Windows.WindowForAdminView  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   H    BSportSectionWPF2.View.Windows.WindowForAdminView.AddScheduleWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Plocal>clr-namespace:SportSectionWPF2.View.Windows.WindowForAdminView     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$  AddScheduleWindow��5	   	   $	��250��6#   $	��400��60   .��5
      �� .+�5   
   �� -   5        $��Вернуться��5      $��15q�5      
��� � �
�������5      �� 5   
   $(��"Дата начала секции��6   $
��Left=�6.    �� Left$ 60��6I   
 �� Top$ 50��6Z   $��Center=�6j   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��	StartDate��5       �� Today   DisplayDateStart# Z 5      $��65,80q�5      �� 5   
   $.��(Дата окончания секции��6   $	 196��61   $ 53��6C     5   
   -   5        $��EndDate��5      # Z 5      $��205,80q�5      �� 5   
   $0��*Время окончания секции��6    J� RenderTransformOrigin$ 0.373,0.479&�62   $
��Left=�6V   $	 191��6q   $	 120��6�   $��Center=�6�   �� 5    
   -   5         ��Name$ EndingTimeTextBox��5       $	��132��5!      $	 195��6   $	 141��60   $
��Left=�6A   $��Center=�6\   �� 5$   
   $*��$Время Начала секции��6   $ 0.373,0.479&�6/   $ 55��6S   $	 120��6d   $
��Left=�6u   $��Center=�6�   �� 5'   
   -   5        $ BeginTimeTextBox��5'      $	��132��5(      $ 49��6   $	 141��6*   $
��Left=�6;   $��Center=�6V   �� 5*   
   -   5        $��Добавить��5*      $��220,180q�5+      $	��100��5,      
�������
��� � �5/      54      55      