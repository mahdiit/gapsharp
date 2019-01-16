namespace GapSharp.DtoModel
{
    public enum RecivedMessageType
    {
        join,
        leave,
        text,
        image,
        video,
        audio,
        file,
        voice,
        triggerButton,
        invoiceCallback,
        payCallback,
        submitForm
    }
}