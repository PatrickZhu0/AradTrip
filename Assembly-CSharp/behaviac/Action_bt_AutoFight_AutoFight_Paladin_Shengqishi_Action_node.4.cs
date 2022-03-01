using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002822 RID: 10274
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node69 : Action
	{
		// Token: 0x06013982 RID: 80258 RVA: 0x005D8B20 File Offset: 0x005D6F20
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node69()
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
			item.skillID = 3706;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013983 RID: 80259 RVA: 0x005D8BB0 File Offset: 0x005D6FB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3DC RID: 54236
		private List<Input> method_p0;

		// Token: 0x0400D3DD RID: 54237
		private bool method_p1;
	}
}
