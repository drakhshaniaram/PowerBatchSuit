[DataContractAttribute]
class PowerBatchSuit_SampleTaskDC
{
    int         inputNumA, inputNumB;
    guid        tGuid;
}

[DataMemberAttribute("InputNumA")]
public int parmInputNumA(int _inputNumA = inputNumA)
{
    inputNumA = _inputNumA;

    return inputNumA;
}

[DataMemberAttribute("InputNumB")]
public int parmInputNumB(int _inputNumB = inputNumB)
{
    inputNumB = _inputNumB;

    return inputNumB;
}

[DataMemberAttribute("TGuid")]
public guid parmTGuid(guid _tGuid = tGuid)
{
    tGuid = _tGuid;

    return tGuid;
}
