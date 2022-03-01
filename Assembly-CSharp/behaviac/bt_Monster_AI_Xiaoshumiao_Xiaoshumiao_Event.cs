using System;

namespace behaviac
{
	// Token: 0x02003E28 RID: 15912
	public static class bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event
	{
		// Token: 0x060163D7 RID: 91095 RVA: 0x006B96FC File Offset: 0x006B7AFC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Xiaoshumiao/Xiaoshumiao_Event");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node3 condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node = new Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node3();
			condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node.HasEvents());
			Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node4 condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node2 = new Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node4();
			condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node2.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node2.HasEvents());
			Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node6 action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node = new Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node6();
			action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node5 condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node3 = new Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node5();
			condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node3.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node3.HasEvents());
			Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node7 condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node4 = new Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node7();
			condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node4.SetId(7);
			sequence2.AddChild(condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node4.HasEvents());
			Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node8 action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node2 = new Action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node8();
			action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node2.SetId(8);
			sequence2.AddChild(action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
