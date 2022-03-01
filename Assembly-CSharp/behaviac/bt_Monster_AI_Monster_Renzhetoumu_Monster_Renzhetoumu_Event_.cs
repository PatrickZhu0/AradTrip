using System;

namespace behaviac
{
	// Token: 0x020036ED RID: 14061
	public static class bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu
	{
		// Token: 0x060155EE RID: 87534 RVA: 0x00672A10 File Offset: 0x00670E10
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Renzhetoumu/Monster_Renzhetoumu_Event_shunshenshu");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node1 action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node = new Action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node1();
			action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			sequence.AddChild(sequence2);
			Condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node3 condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node = new Condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node3();
			condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node.HasEvents());
			Condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node4 condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node2 = new Condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node4();
			condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node2.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node2.HasEvents());
			Action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node5 action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node2 = new Action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node5();
			action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node2.SetId(5);
			sequence2.AddChild(action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Monster_Renzhetoumu_Monster_Renzhetoumu_Event_shunshenshu_node2.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
