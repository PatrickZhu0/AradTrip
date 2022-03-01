using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003F7C RID: 16252
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node9 : Action
	{
		// Token: 0x06016664 RID: 91748 RVA: 0x006C6A3C File Offset: 0x006C4E3C
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node9()
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
			item.skillID = 5354;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016665 RID: 91749 RVA: 0x006C6ACC File Offset: 0x006C4ECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEB9 RID: 65209
		private List<Input> method_p0;

		// Token: 0x0400FEBA RID: 65210
		private bool method_p1;
	}
}
