class PowerBatchSuit_SampleTaskController extends SysOperationServiceController
{
    #define.BatchJobCaption(" ---- Testing Batch Groups ---")
}

public ClassDescription caption()
{
    return #BatchJobCaption;
}

public void new()
{
    super();
    this.parmClassName(classStr(PowerBatchSuit_SampleTaskService));
    this.parmMethodName(methodStr(PowerBatchSuit_SampleTaskService, RunAvailabilityCheckSubTask));
}

public static void main(Args _args)
{
    PowerBatchSuit_SampleTaskController controller;

    controller = new PowerBatchSuit_SampleTaskController();
    controller.startOperation();
}
