using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F1A RID: 7962
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node58 : Action
	{
		// Token: 0x060127D8 RID: 75736 RVA: 0x00568C58 File Offset: 0x00567058
		public Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node58()
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
			item.skillID = 3112;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060127D9 RID: 75737 RVA: 0x00568CE8 File Offset: 0x005670E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1CF RID: 49615
		private List<Input> method_p0;

		// Token: 0x0400C1D0 RID: 49616
		private bool method_p1;
	}
}
