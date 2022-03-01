using System;

namespace behaviac
{
	// Token: 0x020035BA RID: 13754
	public static class bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi
	{
		// Token: 0x060153A1 RID: 86945 RVA: 0x00665E5C File Offset: 0x0066425C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Mage_yijiabeila/Mage_yijiabeila_Event_yijiabeila_Shunyi");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(7);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node8 action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node = new Action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node8();
			action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node.SetClassNameString("Action");
			action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node.HasEvents());
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			sequence.AddChild(selector);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(1);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2 condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node = new Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2();
			condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node.SetId(2);
			sequence2.AddChild(condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node.HasEvents());
			Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node3 condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2 = new Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node3();
			condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2.HasEvents());
			Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node4 condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node3 = new Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node4();
			condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node3.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node3.HasEvents());
			Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node5 condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node4 = new Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node5();
			condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node4.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node4.HasEvents());
			Action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node6 action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2 = new Action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node6();
			action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selector.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
