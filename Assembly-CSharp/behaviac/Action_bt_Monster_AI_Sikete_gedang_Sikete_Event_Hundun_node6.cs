using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003739 RID: 14137
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node6 : Action
	{
		// Token: 0x0601567D RID: 87677 RVA: 0x006754B8 File Offset: 0x006738B8
		public Action_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 5284;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601567E RID: 87678 RVA: 0x00675548 File Offset: 0x00673948
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F04C RID: 61516
		private List<Input> method_p0;

		// Token: 0x0400F04D RID: 61517
		private bool method_p1;
	}
}
