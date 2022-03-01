using System;

namespace behaviac
{
	// Token: 0x02003561 RID: 13665
	public static class bt_Monster_AI_Heisedadi_Zhaohuan_Event_02
	{
		// Token: 0x060152FE RID: 86782 RVA: 0x00662BA8 File Offset: 0x00660FA8
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Heisedadi/Zhaohuan_Event_02");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node1 action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node = new Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node1();
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node2 action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node2 = new Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node2();
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
