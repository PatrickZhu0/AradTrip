using System;

namespace behaviac
{
	// Token: 0x02003B87 RID: 15239
	public static class bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event
	{
		// Token: 0x06015EC0 RID: 89792 RVA: 0x0069FBAC File Offset: 0x0069DFAC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Zhaohuan_zibaoguai_Event");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(5);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(6);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node13 condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node = new Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node13();
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node.SetId(13);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node7 condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2 = new Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node7();
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2.SetId(7);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node9 condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3 = new Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node9();
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3.SetId(9);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node8 condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4 = new Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node8();
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4.SetId(8);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4.HasEvents());
			Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node10 action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node = new Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node10();
			action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node.SetId(10);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node11 action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2 = new Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node11();
			action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2.SetId(11);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node12 action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3 = new Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node12();
			action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3.SetId(12);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(0);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4 condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node5 = new Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4();
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node5.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node5.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3 condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node6 = new Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3();
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node6.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node6.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node1 condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node7 = new Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node1();
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node7.SetId(1);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node7);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node7.HasEvents());
			Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2 action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4 = new Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node2();
			action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4.SetId(2);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
