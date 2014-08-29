print ""
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)
print "############################# Set State ############################"
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)

for _panel in list_of_panels:
	p = panel.Panel(_panel)
	task = p.SetState(SET_STATE_AWAY_BYPASS)
	task_list.append(task)
	task.next()

for task in task_list:
	for i in task:		
		if i.IsInProgress():
			SendData ("Checking PMaxStateSet for %s..." % i.PanelID())
			time.sleep (5)
		
		if i.IsFailed():
			SendData ("PMaxStateSet %s FAILED    : %s." % (i.PanelID(), i.GetError()))
				
		if i.IsSucceeded():
			SendData ("PMaxStateSet %s SUCCEEDED." % i.PanelID())
			time.sleep (0.5)
						
		time.sleep (0.5)