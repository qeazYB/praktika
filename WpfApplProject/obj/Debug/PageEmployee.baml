   M S B A M L   `   `   `  ����I  EWpfApplProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfApplProject.CommandsWpfApplProject.Commands  5      /clr-namespace:WpfApplProjectWpfApplProject  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5      1&clr-namespace:System;assembly=mscorlibSystem 6@   !    WpfApplProject.PageEmployee   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9command%clr-namespace:WpfApplProject.Commands     5      .localclr-namespace:WpfApplProject     5      Bcol2clr-namespace:System.Collections;assembly=mscorlib     5      6sys&clr-namespace:System;assembly=mscorlib     6@     N� Title$  PageEmployee��5
      .��5      � $��3q�6      SecondWindowStyle#��[  6    � ColumnDefinitions 5   
   �� 5      $
��390* �6   �� 5      $
��210* �6    � RowDefinitions 5   
   �� 5      $	��34* �6   �� 5      $	��36* �6   �� 5      $	��26* �6   �� 5      $
��139* �6   �� 5      $	��59* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridEmployee��5   #   $��0��6      AutoGenerateColumns .  $	��Top=�6Y   $��Center=�6q   $��Center=�6�   $��5��6�   $��
10,54,10,0q�6�   $��2��6�   $	��380��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата подачи��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *RequestDate+  5      $ Фамилия И.О.��6%    6;   �� *Client+  5      $ Техника��6%    66   �� *
TechName+  5      $ Причина��6%    66   �� *Reason+  5       $ Приоритет��6%    68   �� *
Priority+  5!      $ Статус��6%    65   �� *Status+  5"      $/ )Идентификатор датчика��6%    6D   �� *
SensorID+  5#      $- 'Наименование датчика��6%    6C   �� *Sensor.Name+5&      c� 5(   
   -   5         c�Name$ ToolBar1��5(   6   $��2��6   $��0��6&   $	��Top=�6H   $��30��6`   $��0,4,0,0q�6l   .@�5)      �� -   5        	 ��Name$
	 Undo��5)      $
��Undo��6#   
 � ToolTip$D
 >Отменить редактирование/создание��62   $��5,2,5,2q�5*      .��5+      �� $��Images/Undo.png��6   5,      �� 5.      -   5        $
	 Edit��5.      *   $WpfApplProject.Commands.DataCommands   Edit#��Z 6#   $-
 'Редактировать данные��6R   $��5,2,5,2q�5/      .��50      �� $��Images/edit.png��6   51      �� 53      -   5        $
	 Save��53      $
��Save��6#   $%
 Сохранить данные��62   $��5,2,5,2q�54      .��55      �� $��Images/Save.png��6   56      �� 57      -   5        $	 Delete��57         Delete#��Z 6%   $
 Удалить��6V   $��5,2,5,2q�58      .��59      �� $��Images/Delete.png��6   5:      5<      �� 5=   
   $��0��6   $	��100��6$   $��20��60   $��Bottom=�6<   $
��Left=�6W   ���#F0F0F0$��	17,0,0,45q�6�   $��2��6�   �� 6�   $�Список заявок��6�   6�   �� 5>   
   $��1��6   $
��Left=�6$   $��
208,34,0,0q�6?   $
��Wrap=�6S   $	��Top=�6g   �� 5?   
   $��1��6   $
��Left=�6$   $��
147,19,0,0q�6?   $
��Wrap=�6S   $	��Top=�6g   $��2��6   �� 6�    � Language$ ru-ru�6�   �� 6�   �� 6�   $ ru-ru�6�    �� 5@   
   $��PageSensors.xaml?�6   ���#F0F0F0.�6H   #!Фонд оборудования5B      5D      5F       J� CommandBindings 5H      )  #System.Windows.Input.CommandBinding  5I   
   -   5           Command$
 Undo��5I      6A     5K   
   -   5        # Z 5K      6a     5L   
   -	   5        $
 Save��5L      6A     5N   
   -
   5        # Z 5N      6e   5T      