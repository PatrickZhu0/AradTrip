using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002816 RID: 10262
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node49 : Action
	{
		// Token: 0x0601396A RID: 80234 RVA: 0x005D864C File Offset: 0x005D6A4C
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node49()
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
			item.skillID = 3703;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601396B RID: 80235 RVA: 0x005D86DC File Offset: 0x005D6ADC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3C7 RID: 54215
		private List<Input> method_p0;

		// Token: 0x0400D3C8 RID: 54216
		private bool method_p1;
	}
}
