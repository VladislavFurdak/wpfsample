   M S B A M L   `   `   `  ����H  DReferenceData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ReferenceData.ValidationReferenceData.Validation  5      !    ReferenceData.View.UserView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =
validation&clr-namespace:ReferenceData.Validation     5      $��789.727��5      $
��Auto��6     � 	Resources  5       �� 
TargetType �� Property �� Value��%�  '��       '�� �     '�� 2    '�� �    �� 5      " ��6   .�5      ��  � ��$	 100��6*   �� 5	       � ��$ 30��6+   �� 5
       � ��$ 
10,10,20,0q�6+   5      �� 5      " ��6   .�5      ��  � ��$	 140��6&   �� 5       � ��$ 30��6+   �� 5       � ��$ 
10,10,20,0q�6+   5      �� 5      " ��6   .�5      ��  � ��$	 140��6*   �� 5       � ��$ 30��6+   �� 5       � ��$ 
10,10,20,0q�6+   5      �� 5      " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 
10,10,10,0q�6'   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6    � RowDefinitions 5"   
   �� 5#      $��15 �6   �� 5$      $��* �6   �� 5%      $��1.35* �6   .+�5'   
   �� $��Stretch=�6   $��15��6=   .��5(      � -   5         �Name$ progress��5*      $��0��5(      $��0��5)      $
��Left=�5+      $��15��5,      $	��Top=�5-      $��3��5.       � IsIndeterminate . $	��200��50      {�. 51      52      &   System.Windows.Controls.DataGrid  53   
   -   5          Name$ UserGrid��53      $	��Top=�54      $��0��55      $��1��56      $	��263��58      	 %� IsVirtualizing	 . 
   AutoGenerateColumns
 .     EnableRowVirtualization . !   EnableColumnVirtualization .    
IsReadOnly . $��4��5?       �� SelectedItem 57      �� *SelectedItem+ �� Mode$ TwoWay=���5:      �� *
UserList+$ TwoWay=� �� IsAsync .    Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      
Visibility$ Hidden=�6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6M     5B      $ 	FirstName��6)    6<   �� *	FirstName+  5C      $ 
SecondName��6)    6=   �� *
SecondName+  5D      $ Country��6)    6:   �� *	Country+  5E      $ SubDivision��6)    6>   �� *Subdivision+  5F      $ Location��6)    6;   �� *
Location+5H      �� 5I   
   $��3��6   $��0��6"    �� Orientation$ Vertical=�62   $��3��6I   .+�5J      �� $ 
Horizontal=�6   .+�5K      �� $��
FirstName:��6   $��1��5L      $��1��5M      �� 5N      -   5         ��Name$ 	FirstName��5N      $��2��5O      $��1��5P      .��6'   ��5Q      �� 5R       �� Path$ SelectedItem.FirstName�6"    �� UpdateSourceTrigger$ PropertyChanged=�6@   $ TwoWay=�6f    �� ValidationRules 5S      4   .ReferenceData.Validation.TextBoxValidationRule  5T   "   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated . 6C   5V      .��5W   $   5X      5Y      �� 5Z      $ 
Horizontal=�6   .+�5[      �� $��SecondName:��6   $��1��5\      $��1��5]      �� 5^      -   5        $ 
SecondName��5^      $��2��5_      $��1��5`      .��6(   .��5a      �� $ SelectedItem.SecondName�6   $ PropertyChanged=�6=   $ TwoWay=�6c    5b        5c       . 6?   5e      5f      5g      �� 5h      $ 
Horizontal=�6   .+�5i      �� $��Country:��6   �� 5j      -   5         ��Name$ Country��5k       �� SelectedValuePath$	 Key��5m       �� DisplayMemberPath$ Value.Description��5n      	 .  %� VirtualizationMode$ 	Recycling=�5p      ��5l      �� *GetSimpleCountryList+$ OneWay=���5q      �� 5r      .R�5s      $� 5t       �� SelectedValue 5v      �� 5w      $ SelectedItem.CountryId�6"   $ OneWay=�6@    5x      6   0ReferenceData.Validation.SelectionValidationRule  5y   "    . 6F   5{      5}      5~      �� 5      $ 
Horizontal=�6   .+�5�      �� $��Subdivision:��6   $��1��5�      $��1��5�      �� 5�      -   5        $ Subdivision��5�      $	 Key��5�      $ Value.Description��5�      	 . $ 	Recycling=�5�      ��5�      �� *GetSimpleSubdivisionList+$ OneWay=� 5�      �� *SelectedItem.SubdivisionId+$ OneWay=���5�      �� 5�      .R�5�      $� 5�      5�      5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��	Location:��6   �� 5�      -   5        $ Location��5�      $	 Key��5�      $ Value.Description��5�      	 . $ 	Recycling=�5�      ��5�      �� *GetSimpleLocationList+$ OneWay=� 5�      �� *SelectedItem.LocationId+$ TwoWay=���5�      �� 5�      .R�5�      $� 5�      5�      5�      �� 5�      $ 
Horizontal=�6   $��Center=�62   .+�5�      �� $	��New��6   ��6'   �� *
NewCommand+�� 5�      $
��Save��6   ��6(   �� *SaveCommand+�� 5�      $��Cancel��6   ��6+   �� *CancelCommand+5�      5�      5�      5�      