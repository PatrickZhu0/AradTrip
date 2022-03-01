using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02001370 RID: 4976
[Serializable]
public class ConditionTrigger
{
	// Token: 0x04006D26 RID: 27942
	[SerializeField]
	public ConditionTrigger.ConditionEvent m_TimeEvent = new ConditionTrigger.ConditionEvent();

	// Token: 0x02001371 RID: 4977
	[Serializable]
	public class ConditionEvent : UnityEvent
	{
	}
}
