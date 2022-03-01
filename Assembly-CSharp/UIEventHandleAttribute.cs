using System;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000DE7 RID: 3559
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class UIEventHandleAttribute : Attribute
{
	// Token: 0x06008F58 RID: 36696 RVA: 0x001A8976 File Offset: 0x001A6D76
	public UIEventHandleAttribute(string controlName)
	{
		this.controlName = controlName;
		this.eventType = typeof(UnityAction);
		this.controlType = typeof(Button);
		this.start = 0;
		this.end = 0;
	}

	// Token: 0x06008F59 RID: 36697 RVA: 0x001A89B3 File Offset: 0x001A6DB3
	public UIEventHandleAttribute(string controlName, Type controlType, Type eventType, int start = 0, int end = 0)
	{
		this.controlName = controlName;
		this.eventType = eventType;
		this.controlType = controlType;
		this.start = start;
		this.end = end;
	}

	// Token: 0x04004724 RID: 18212
	public string controlName;

	// Token: 0x04004725 RID: 18213
	public Type eventType;

	// Token: 0x04004726 RID: 18214
	public Type controlType;

	// Token: 0x04004727 RID: 18215
	public int start;

	// Token: 0x04004728 RID: 18216
	public int end;
}
