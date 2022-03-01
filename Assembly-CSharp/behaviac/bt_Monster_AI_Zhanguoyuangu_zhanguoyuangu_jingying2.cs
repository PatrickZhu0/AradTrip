using System;

namespace behaviac
{
	// Token: 0x02003F5A RID: 16218
	public static class bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2
	{
		// Token: 0x06016623 RID: 91683 RVA: 0x006C5464 File Offset: 0x006C3864
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Zhanguoyuangu/zhanguoyuangu_jingying2");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3 condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node = new Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3();
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node.HasEvents());
			Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4 condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2 = new Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4();
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2.HasEvents());
			Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5 condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3 = new Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5();
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3.HasEvents());
			Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6 action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node = new Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6();
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node.SetClassNameString("Action");
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node.HasEvents());
			Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node7 assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node = new Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node7();
			assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node.SetId(7);
			sequence.AddChild(assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node9 condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4 = new Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node9();
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4.SetId(9);
			sequence2.AddChild(condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4.HasEvents());
			Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node8 condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5 = new Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node8();
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5.HasEvents());
			Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node10 condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6 = new Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node10();
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6.HasEvents());
			Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node11 action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2 = new Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node11();
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2.SetId(11);
			sequence2.AddChild(action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2.HasEvents());
			Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node13 action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3 = new Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node13();
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3.SetId(13);
			sequence2.AddChild(action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node3.HasEvents());
			Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node14 action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4 = new Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node14();
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4.SetId(14);
			sequence2.AddChild(action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node4.HasEvents());
			Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node16 action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5 = new Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node16();
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5.SetId(16);
			sequence2.AddChild(action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5.HasEvents());
			Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node15 action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6 = new Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node15();
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6.SetId(15);
			sequence2.AddChild(action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node6.HasEvents());
			Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node12 assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2 = new Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node12();
			assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2.SetId(12);
			sequence2.AddChild(assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
