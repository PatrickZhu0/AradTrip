using System;
using YIMEngine;

// Token: 0x02004AAB RID: 19115
public class MessageCallbackObject
{
	// Token: 0x0601BC0D RID: 113677 RVA: 0x0088309D File Offset: 0x0088149D
	public MessageCallbackObject(IMMessage msg, MessageBodyType msgType, object call)
	{
		this.callback = call;
		this.message = msg;
		this.msgType = msgType;
	}

	// Token: 0x0401358E RID: 79246
	public object callback;

	// Token: 0x0401358F RID: 79247
	public IMMessage message;

	// Token: 0x04013590 RID: 79248
	public MessageBodyType msgType;
}
