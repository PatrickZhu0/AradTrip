using System;

namespace behaviac
{
	// Token: 0x020040D4 RID: 16596
	public static class bt_DestinationSelectBT
	{
		// Token: 0x060168FD RID: 92413 RVA: 0x006D51B4 File Offset: 0x006D35B4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("DestinationSelectBT");
			bt.IsFSM = false;
			Action_bt_DestinationSelectBT_node0 action_bt_DestinationSelectBT_node = new Action_bt_DestinationSelectBT_node0();
			action_bt_DestinationSelectBT_node.SetClassNameString("Action");
			action_bt_DestinationSelectBT_node.SetId(0);
			bt.AddChild(action_bt_DestinationSelectBT_node);
			bt.SetHasEvents(bt.HasEvents() | action_bt_DestinationSelectBT_node.HasEvents());
			return true;
		}
	}
}
