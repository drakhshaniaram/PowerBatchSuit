class PowerBatchSuit
{
}

private static Set checkReponse(Map _guidOfBatchGroupId, Map _expectedOutputOfGuid)
{
    LogOnDBWebServiceBus     logOnDBWebServiceBus;
    MapEnumerator            guidEnumerator = _guidOfBatchGroupId.getEnumerator();
    MapEnumerator            resultsEnumerator = _expectedOutputOfGuid.getEnumerator();
    guid                     currentGuid, resultGuid;
    str                      currentResult;
    BatchGroupId             currentBatchGroupId;
    Set                      ret = new Set(Types::String);

    while(guidEnumerator.moveNext())
    {
        currentBatchGroupId = guidEnumerator.currentKey();
        currentGuid = guidEnumerator.currentValue();

        select * from logOnDBWebServiceBus where logOnDBWebServiceBus.TrackGuid == currentGuid;


        while(resultsEnumerator.moveNext())
        {
            resultGuid = resultsEnumerator.currentKey();
            if(currentGuid == resultGuid)
            {
                currentResult = resultsEnumerator.currentValue();
                if(logOnDBWebServiceBus.RecId && logOnDBWebServiceBus.Message == currentResult)
                    ret.add(currentBatchGroupId);
            }
        }


    }

    return ret;
}

public static Set getAllBatchGroupsList()
{
    BatchGroup      batchGroup;
    Set             ret = new Set(Types::String);

    while select *
    from batchGroup group by batchGroup.Group
    {
        ret.add(batchGroup.Group);
    }

    return ret;
}

public static Set getResponsiveBatchGroupsList()
{
    BatchGroup                              batchGroup;
    Set                                     ret = new Set(Types::String);
    PowerBatchSuit_SampleTaskController     runTaskController;
    PowerBatchSuit_SampleTaskDC             runTaskDataContract;
    BatchGroupId                            currentBatchGroupId;
    guid                                    tGuid;
    int                                     inputA;
    int                                     inputB;
    int                                     correctResult;
    Map                                     guidOfBatchGroupId = new Map(Types::String, Types::Guid);
    Map                                     expectedOutputOfGuid = new Map(Types::Guid, Types::String);


    while select *
    from batchGroup group by batchGroup.Group
    {
        inputA = RandomGenerate::construct().randomInt(1, 9);
        inputB = RandomGenerate::construct().randomInt(10, 90);
        correctResult = inputA * inputB;
        tGuid = newGuid();

        currentBatchGroupId = batchGroup.Group;

        runTaskController = new PowerBatchSuit_SampleTaskController();
        runTaskController.parmReliableAsyncBatchGroupId(currentBatchGroupId);
        runTaskDataContract = runTaskController.getDataContractObject();
        runTaskDataContract.parmInputNumA(inputA);
        runTaskDataContract.parmInputNumB(inputB);
        runTaskDataContract.parmTGuid(tGuid);

        guidOfBatchGroupId.insert(currentBatchGroupId, tGuid);
        expectedOutputOfGuid.insert(tGuid, correctResult);
        runTaskController.run();
    }

    sleep(70000);

    ret = PowerBatchSuit::checkReponse(guidOfBatchGroupId, expectedOutputOfGuid);

    return ret;
}

