USE [HolidaysDb]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [Name], [LastName]) VALUES (7, N'Marta', N'')
INSERT [dbo].[Client] ([Id], [Name], [LastName]) VALUES (8, N'Yair', N'')
INSERT [dbo].[Client] ([Id], [Name], [LastName]) VALUES (9, N'asd', N'')
INSERT [dbo].[Client] ([Id], [Name], [LastName]) VALUES (10, N'Anto', N'')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([Id], [NameService]) VALUES (1, N'Servicio de Peluquería')
INSERT [dbo].[Service] ([Id], [NameService]) VALUES (2, N'Servicio de Spa')
INSERT [dbo].[Service] ([Id], [NameService]) VALUES (3, N'Servicio de Mantenimiento')
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([Id], [Date], [Time], [Reserved], [IdService], [ClientId]) VALUES (15, CAST(N'2025-04-01T00:00:00.0000000' AS DateTime2), CAST(N'14:00:00' AS Time), 0, 1, NULL)
INSERT [dbo].[Booking] ([Id], [Date], [Time], [Reserved], [IdService], [ClientId]) VALUES (16, CAST(N'2025-04-01T00:00:00.0000000' AS DateTime2), CAST(N'15:00:00' AS Time), 0, 1, NULL)
INSERT [dbo].[Booking] ([Id], [Date], [Time], [Reserved], [IdService], [ClientId]) VALUES (17, CAST(N'2025-04-01T00:00:00.0000000' AS DateTime2), CAST(N'10:00:00' AS Time), 0, 2, NULL)
INSERT [dbo].[Booking] ([Id], [Date], [Time], [Reserved], [IdService], [ClientId]) VALUES (18, CAST(N'2025-04-01T00:00:00.0000000' AS DateTime2), CAST(N'11:00:00' AS Time), 0, 2, NULL)
INSERT [dbo].[Booking] ([Id], [Date], [Time], [Reserved], [IdService], [ClientId]) VALUES (19, CAST(N'2025-04-01T00:00:00.0000000' AS DateTime2), CAST(N'08:00:00' AS Time), 0, 3, NULL)
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250322000812_a', N'8.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250322001316_b', N'8.0.14')
GO
