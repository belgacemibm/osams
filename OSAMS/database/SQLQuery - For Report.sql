-- =============================================
-- Author:		Vo Ngoc Diep
-- Create date: 02/05/2012
-- Description:	Script to create Views, Functions, Stored Procedures
-- =============================================

/*Create Views */
GO
/****** Object:  View [dbo].[presentview]    Script Date: 05/02/2012 15:08:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[presentview]
AS
SELECT     dbo.[group].group_id, dbo.[group].group_name, dbo.[group].semester_name, dbo.[group].course_id, dbo.student_schedule.status, dbo.schedule.date, 
                      dbo.student.gender
FROM         dbo.[group] INNER JOIN
                      dbo.schedule ON dbo.[group].group_id = dbo.schedule.group_id INNER JOIN
                      dbo.student_schedule ON dbo.schedule.schedule_id = dbo.student_schedule.schedule_id INNER JOIN
                      dbo.student ON dbo.student_schedule.student_id = dbo.student.student_id
WHERE     (dbo.student_schedule.status = 'present')


GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "group"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "schedule"
            Begin Extent = 
               Top = 6
               Left = 252
               Bottom = 121
               Right = 404
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "student_schedule"
            Begin Extent = 
               Top = 6
               Left = 442
               Bottom = 121
               Right = 622
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "student"
            Begin Extent = 
               Top = 7
               Left = 654
               Bottom = 122
               Right = 806
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      En' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'presentview'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'd
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'presentview'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'presentview'


GO
/****** Object:  View [dbo].[absentview]    Script Date: 05/02/2012 15:08:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[absentview]
AS
SELECT     dbo.[group].group_id, dbo.[group].group_name, dbo.[group].semester_name, dbo.[group].course_id, dbo.student_schedule.status, dbo.schedule.date, 
                      dbo.student.gender
FROM         dbo.[group] INNER JOIN
                      dbo.schedule ON dbo.[group].group_id = dbo.schedule.group_id INNER JOIN
                      dbo.student_schedule ON dbo.schedule.schedule_id = dbo.student_schedule.schedule_id INNER JOIN
                      dbo.student ON dbo.student_schedule.student_id = dbo.student.student_id
WHERE     (dbo.student_schedule.status = 'absent')


GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "group"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "schedule"
            Begin Extent = 
               Top = 6
               Left = 252
               Bottom = 121
               Right = 404
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "student_schedule"
            Begin Extent = 
               Top = 6
               Left = 442
               Bottom = 121
               Right = 622
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "student"
            Begin Extent = 
               Top = 16
               Left = 653
               Bottom = 131
               Right = 805
            End
            DisplayFlags = 280
            TopColumn = 5
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      E' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'absentview'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'nd
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'absentview'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'absentview'


GO
/****** Object:  View [dbo].[SessionPresentView]    Script Date: 05/02/2012 15:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SessionPresentView]
AS
SELECT     g.group_id, s.date, gd.type, dbo.student_schedule.status
FROM         dbo.group_day AS gd INNER JOIN
                      dbo.[group] AS g ON gd.group_id = g.group_id INNER JOIN
                      dbo.schedule AS s ON g.group_id = s.group_id INNER JOIN
                      dbo.student_schedule ON s.schedule_id = dbo.student_schedule.schedule_id
WHERE     (dbo.student_schedule.status = 'present')

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "g"
            Begin Extent = 
               Top = 19
               Left = 48
               Bottom = 134
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 137
               Left = 309
               Bottom = 252
               Right = 461
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "gd"
            Begin Extent = 
               Top = 6
               Left = 384
               Bottom = 121
               Right = 536
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "student_schedule"
            Begin Extent = 
               Top = 6
               Left = 574
               Bottom = 121
               Right = 754
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
En' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'SessionPresentView'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'd
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'SessionPresentView'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'SessionPresentView'


GO
/****** Object:  View [dbo].[SessionAbsentView]    Script Date: 05/02/2012 15:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SessionAbsentView]
AS
SELECT     g.group_id, s.date, gd.type, dbo.student_schedule.status
FROM         dbo.group_day AS gd INNER JOIN
                      dbo.[group] AS g ON gd.group_id = g.group_id INNER JOIN
                      dbo.schedule AS s ON g.group_id = s.group_id INNER JOIN
                      dbo.student_schedule ON s.schedule_id = dbo.student_schedule.schedule_id
WHERE     (dbo.student_schedule.status = 'absent')

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "gd"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "g"
            Begin Extent = 
               Top = 6
               Left = 228
               Bottom = 121
               Right = 404
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 6
               Left = 442
               Bottom = 121
               Right = 594
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "student_schedule"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 241
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'SessionAbsentView'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'SessionAbsentView'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'SessionAbsentView'


/*Create Functions*/
GO
/****** Object:  UserDefinedFunction [dbo].[presentfunction]    Script Date: 05/02/2012 15:12:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[presentfunction] 
(	
	-- Add the parameters for the function here
	@start_date datetime,
	@end_date datetime
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT group_id, count(status) as present from presentview where (date between @start_date and @end_date) group by group_id
)


GO
/****** Object:  UserDefinedFunction [dbo].[absentfunction]    Script Date: 05/02/2012 15:13:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[absentfunction]
(	
	-- Add the parameters for the function here
	@start_date datetime,
	@end_date datetime
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT group_id, count(status) as absent from absentview where (date between @start_date and @end_date) group by group_id
)


GO
/****** Object:  UserDefinedFunction [dbo].[reportfunction]    Script Date: 05/02/2012 15:13:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[reportfunction]
(	
	-- Add the parameters for the function here
	  @start_date datetime,
      @end_date datetime
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select a.group_id, isnull(cast(a.present as int),0) as present, (isnull(a.present,0)*1.0/(isnull(a.present,0) + isnull(b.absent,0)))*100 as present_percentage,
 Isnull(cast(b.absent as int),0) as absent, (isnull(b.absent,0)*1.0/(isnull(a.present,0) + isnull(b.absent,0)))*100 as absent_percentage, (isnull(a.present,0) + isnull(b.absent,0)) as group_total from presentfunction(@start_date, @end_date) a full join absentfunction(@start_date, @end_date) b on a.group_id = b.group_id
)


/*Create Stored Procedures*/
GO
/****** Object:  StoredProcedure [dbo].[summaryreport]    Script Date: 05/02/2012 15:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[summaryreport] 
	-- Add the parameters for the stored procedure here
	  --@group_id int,
	  @start_date datetime,
      @end_date datetime
AS
select a.semester_name, a.course_id, a.group_name, a.group_id, b.present, b.present_percentage,
b.absent, b.absent_percentage, b.group_total from [group] as a, reportfunction(@start_date,@end_date) as b
where a.group_id = b.group_id and b.group_id in (1,4)


GO
/****** Object:  StoredProcedure [dbo].[summaryreport2]    Script Date: 05/02/2012 15:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[summaryreport2]
@group_id nvarchar(max),
@start_date datetime,
@end_date datetime
as
create table #GroupIDs
(GroupID bigint)
Declare @GroupsSQL nvarchar(max);
Select @GroupsSQL = 'Insert into #GroupIDs (GroupID)
	SELECT [group_id] FROM [group] WHERE (group_id in (' + @group_id + '))'
exec sp_executesql @GroupsSQL
select a.semester_name, a.course_id, a.group_name, a.group_id, b.present, b.present_percentage,
b.absent, b.absent_percentage, b.group_total from [group] as a, reportfunction(@start_date,@end_date) as b
where a.group_id = b.group_id and b.group_id in (select GroupID from #GroupIDs)


GO
/****** Object:  StoredProcedure [dbo].[GenderPresent]    Script Date: 05/02/2012 15:15:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GenderPresent]
	-- Add the parameters for the stored procedure here
	@group_id nvarchar(max),
	@start_date datetime,
	@end_date datetime
AS
    -- Insert statements for procedure here
create table #GroupIDs
(GroupID bigint)
Declare @GroupsSQL nvarchar(max);
Select @GroupsSQL = 'Insert into #GroupIDs (GroupID)
	SELECT [group_id] FROM [group] WHERE (group_id in (' + @group_id + '))'
exec sp_executesql @GroupsSQL
SELECT gender, count(status) as present from presentview where (date between @start_date and @end_date) and group_id in (select GroupID from #GroupIDs) group by gender


GO
/****** Object:  StoredProcedure [dbo].[GenderAbsent]    Script Date: 05/02/2012 15:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GenderAbsent]
	-- Add the parameters for the stored procedure here
	@group_id nvarchar(max),
	@start_date datetime,
	@end_date datetime
AS
BEGIN
create table #GroupIDs
(GroupID bigint)
Declare @GroupsSQL nvarchar(max);
Select @GroupsSQL = 'Insert into #GroupIDs (GroupID)
	SELECT [group_id] FROM [group] WHERE (group_id in (' + @group_id + '))'
exec sp_executesql @GroupsSQL
SELECT gender, count(status) as absent from absentview where (date between @start_date and @end_date) and group_id in (select GroupID from #GroupIDs) group by gender
END


GO
/****** Object:  StoredProcedure [dbo].[GenderReportTemp]    Script Date: 05/02/2012 15:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GenderReportTemp] 
	-- Add the parameters for the stored procedure here
	@group_id nvarchar(50),
	@start_date datetime,
	@end_date datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select a.gender, b.present, b.present_percentage,
b.absent, b.absent_percentage, b.group_total from [presentview] as a, reportfunction(@start_date,@end_date) as b
where a.group_id = b.group_id and b.group_id in (1,4)
END


GO
/****** Object:  StoredProcedure [dbo].[GenderReport]    Script Date: 05/02/2012 15:16:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GenderReport] 
	-- Add the parameters for the stored procedure here
	@group_id nvarchar(50),
	@start_date datetime,
	@end_date datetime
AS
BEGIN
    -- Insert statements for procedure here
CREATE TABLE #GenderPresent
(
  gender nvarchar(20),  present int
)
INSERT #GenderPresent EXEC GenderPresent @group_id, @start_date, @end_date
CREATE TABLE #GenderAbsent
(
  gender nvarchar(20),  absent int
)
INSERT #GenderAbsent EXEC GenderAbsent @group_id, @start_date, @end_date
select a.gender, isnull(cast(a.present as int),0) as present, (isnull(a.present,0)*1.0/(isnull(a.present,0) + isnull(b.absent,0)))*100 as present_percentage,
 Isnull(cast(b.absent as int),0) as absent, (isnull(b.absent,0)*1.0/(isnull(a.present,0) + isnull(b.absent,0)))*100 as absent_percentage, (isnull(a.present,0) + isnull(b.absent,0)) as group_total from #GenderPresent a full join #GenderAbsent b on a.gender = b.gender
END


GO
/****** Object:  StoredProcedure [dbo].[SessionPresent]    Script Date: 05/02/2012 15:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SessionPresent]
	-- Add the parameters for the stored procedure here
	@group_id nvarchar(max),
	@start_date datetime,
	@end_date datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	create table #GroupIDs
(GroupID bigint)
Declare @GroupsSQL nvarchar(max);
Select @GroupsSQL = 'Insert into #GroupIDs (GroupID)
	SELECT [group_id] FROM [group] WHERE (group_id in (' + @group_id + '))'
exec sp_executesql @GroupsSQL
SELECT [type], count(status) as present from SessionPresentView where (date between @start_date and @end_date) and group_id in (select GroupID from #GroupIDs) group by [type]
END


GO
/****** Object:  StoredProcedure [dbo].[SessionAbsent]    Script Date: 05/02/2012 15:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SessionAbsent]
	-- Add the parameters for the stored procedure here
	@group_id nvarchar(max),
	@start_date datetime,
	@end_date datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	create table #GroupIDs
(GroupID bigint)
Declare @GroupsSQL nvarchar(max);
Select @GroupsSQL = 'Insert into #GroupIDs (GroupID)
	SELECT [group_id] FROM [group] WHERE (group_id in (' + @group_id + '))'
exec sp_executesql @GroupsSQL
SELECT [type], count(status) as absent from SessionAbsentView where (date between @start_date and @end_date) and group_id in (select GroupID from #GroupIDs) group by [type]
END


GO
/****** Object:  StoredProcedure [dbo].[SessionReportTempt]    Script Date: 05/02/2012 15:18:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SessionReportTempt]
	-- Add the parameters for the stored procedure here
	@group_id nvarchar(50),
	@start_date datetime,
	@end_date datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select c.[type], b.present, b.present_percentage,
b.absent, b.absent_percentage, b.group_total from [presentview] as a, reportfunction(@start_date,@end_date) as b, SessionPresentView as c
where a.group_id = b.group_id and b.group_id in (1,4)
END


GO
/****** Object:  StoredProcedure [dbo].[SessionReport]    Script Date: 05/02/2012 15:18:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SessionReport] 
	-- Add the parameters for the stored procedure here
	@group_id nvarchar(50),
	@start_date datetime,
	@end_date datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	CREATE TABLE #SessionPresent
(
  type nvarchar(20),  present int
)
INSERT #SessionPresent EXEC SessionPresent @group_id, @start_date, @end_date
CREATE TABLE #SessionAbsent
(
  type nvarchar(20),  absent int
)
INSERT #SessionAbsent EXEC SessionAbsent @group_id, @start_date, @end_date
select a.type, isnull(cast(a.present as int),0) as present, (isnull(a.present,0)*1.0/(isnull(a.present,0) + isnull(b.absent,0)))*100 as present_percentage,
 Isnull(cast(b.absent as int),0) as absent, (isnull(b.absent,0)*1.0/(isnull(a.present,0) + isnull(b.absent,0)))*100 as absent_percentage, (isnull(a.present,0) + isnull(b.absent,0)) as group_total from #SessionPresent a full join #SessionAbsent b on a.[type] = b.[type]
END
