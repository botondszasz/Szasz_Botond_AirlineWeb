using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Szasz_Botond_AirlineWeb.Data;

namespace Szasz_Botond_AirlineWeb.Models
{
    public class ReservationDetailsPageModel : PageModel
    {
        public List<AssignedDetailData> AssignedDetailDataList;
        public void PopulateAssignedDetailData(Szasz_Botond_AirlineWebContext context, Reservation reservation)
        {
            var allDetails = context.Detail;
            var reservationDetails = new HashSet<int>(
            reservation.ReservationDetails.Select(c => c.DetailID));
            AssignedDetailDataList = new List<AssignedDetailData>();
            foreach (var det in allDetails)
            {
                AssignedDetailDataList.Add(new AssignedDetailData
                {
                    DetailID = det.ID,
                    Name = det.DetailName,
                    Assigned = reservationDetails.Contains(det.ID)
                });
            }
        }
        public void UpdateReservationDetails(Szasz_Botond_AirlineWebContext context,
        string[] selectedDetails, Reservation reservationToUpdate)
        {
            if (selectedDetails == null)
            {
                reservationToUpdate.ReservationDetails = new List<ReservationDetail>();
                return;
            }
            var selectedDetailsHS = new HashSet<string>(selectedDetails);
            var reservationDetails = new HashSet<int>
            (reservationToUpdate.ReservationDetails.Select(c => c.Detail.ID));
            foreach (var det in context.Detail)
            {
                if (selectedDetailsHS.Contains(det.ID.ToString()))
                {
                    if (!reservationDetails.Contains(det.ID))
                    {
                        reservationToUpdate.ReservationDetails.Add(
                        new ReservationDetail
                        {
                            ReservationID = reservationToUpdate.ID,
                            DetailID = det.ID
                        });
                    }
                }
                else
                {
                    if (reservationDetails.Contains(det.ID))
                    {
                        ReservationDetail courseToRemove
                        = reservationToUpdate
                        .ReservationDetails
                        .SingleOrDefault(i => i.DetailID == det.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
