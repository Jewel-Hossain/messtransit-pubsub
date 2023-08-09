//In the name of Allah

namespace Messtransit.My.Utils;

public abstract class QueueNames
{
    public const string REPORT_SERVICE_QUEUE = "queue:report-service-queue";
    public const string RESTAURANT_SERVICE_QUEUE = "queue:restaurant-service-queue";
}//class

public abstract class QueueRoutes
{
    public const string REPORT_SERVICE_QUEUE_ROUTE = "report-service-queue";
    public const string RESTAURANT_SERVICE_QUEUE_ROUTE  = "restaurant-service-queue";
}//class