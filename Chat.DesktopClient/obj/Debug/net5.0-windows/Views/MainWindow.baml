   M S B A M L   `   `   `  ����M  IChat.DesktopClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Chat.DesktopClient.ViewModelsChat.DesktopClient.ViewModels  5   0   )    #Chat.DesktopClient.Views.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VPrism.Unity.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   >
viewmodels+clr-namespace:Chat.DesktopClient.ViewModels   60   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5	   	    � Title$
 Chat��5
   	   $	��450��6   $	��800��6#   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ Yellow��6    � Offset$	 0.0Q�6*   � 5      $	 Red��6   $
 0.25Q�6'   � 5      $
 Blue��6   $
 0.75Q�6(   � 5      $ 	LimeGreen��6   $	 1.0Q�6-   5      .��5      � $��140,31,140,50q�6    � ColumnDefinitions 5   
   �� 5      $	��21* �6   �� 5      $��5* �6    � RowDefinitions 5   
   �� 5      $
��308* �6   �� 5      $	��45* �6   .+�5   
   �� $��2��6   .��5      �� 
���������6   �� *ReceivedMessages+6:   5      �� 5   
   $��1��6\   $��0��6i   ��6   �� *MessageStringToSend+ �� UpdateSourceTrigger$ PropertyChanged=�6i   �� 5    
   $
��Send��6   	 �� 	IsDefault$
	 True��6G   $��1��6X   $��1��6e   ��6    �� *SendMessageCommand+6e   5!      5"      