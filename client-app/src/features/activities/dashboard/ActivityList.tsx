import { observer } from 'mobx-react-lite';
import { Fragment } from 'react';
import { Header, Segment } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';
import ActivityListItem from './ActivityListItem';

export default observer(function ActivityList() {
    const { activityStore } = useStore();
    const { groupedActivities } = activityStore

    return (
        <>
            {groupedActivities.map(([group, activities], index) => (
                <Fragment key={index}>
                    <Header sub color='teal'>
                        {group}
                    </Header>
                    {activities.map(activity => (
                        <ActivityListItem key={activity.id} activity={activity} />
                    ))}
                </Fragment>
            ))}
        </>
    )
})