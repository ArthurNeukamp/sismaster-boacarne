Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    ' **NEW** ApplyApplicationDefaults: Raised when the application queries default values to be set for the application.

    ' Example:
    ' Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
    '
    '   ' Setting the application-wide default Font:
    '   e.Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular)
    '
    '   ' Setting the HighDpiMode for the Application:
    '   e.HighDpiMode = HighDpiMode.PerMonitorV2
    '
    '   ' If a splash dialog is used, this sets the minimum display time:
    '   e.MinimumSplashScreenDisplayTime = 4000
    ' End Sub

    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf OnUnhandledExceptionBg
            AddHandler System.Threading.Tasks.TaskScheduler.UnobservedTaskException, AddressOf OnUnobservedTaskException
            LogService.GravarInfo("SISTEMA", "Iniciando SisMaster...")
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            LogService.GravarErro("SISTEMA", "Exceção Não Tratada na Thread Principal (UI): " & e.Exception.ToString())
        End Sub

        Private Sub OnUnhandledExceptionBg(sender As Object, e As UnhandledExceptionEventArgs)
            Dim ex As Exception = TryCast(e.ExceptionObject, Exception)
            If ex IsNot Nothing Then
                LogService.GravarErro("SISTEMA", "Exceção Não Tratada em Background Thread: " & ex.ToString())
            End If
        End Sub

        Private Sub OnUnobservedTaskException(sender As Object, e As System.Threading.Tasks.UnobservedTaskExceptionEventArgs)
            If e.Exception IsNot Nothing Then
                LogService.GravarErro("SISTEMA", "Exceção Não Tratada em Task Assíncrona: " & e.Exception.ToString())
            End If
            e.SetObserved()
        End Sub

    End Class
End Namespace
