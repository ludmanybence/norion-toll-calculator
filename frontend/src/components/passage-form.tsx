import { ChangeEvent, useEffect, useState } from "react";

interface Props {
  addPassage: (passage: Date) => void;
  onAdded: () => void;
}

const PassageForm = ({ addPassage, onAdded }: Props) => {
  const [selectedDate, setSelectedDate] = useState<string>("");
  const [selectedTime, setSelectedTime] = useState<string>("");

  const onDateInputChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSelectedDate(e.target.value);
  };

  const onTimeInputChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSelectedTime(e.target.value);
  };

  const submitButtonPressed = () => {
    if (selectedDate && selectedTime) {

      const [year,month,day] = selectedDate.split("-");
      const [hour,minute] = selectedTime.split(":");

      addPassage(
        new Date(parseInt(year), parseInt(month)-1, parseInt(day), parseInt(hour), parseInt(minute))
      );
    }

    onAdded();
  };

  useEffect(() => {
    const now = new Date(Date.now());
    const year = now.toLocaleString("default", { year: "numeric" });
    const month = now.toLocaleString("default", { month: "2-digit" });
    const day = now.toLocaleString("default", { day: "2-digit" });
    const formattedDate = year + "-" + month + "-" + day;

    const formattedTime = now.toLocaleTimeString("sv-SE").split(" ")[0];
    setSelectedDate(formattedDate);
    setSelectedTime(formattedTime);
  }, []);

  return (
    <div className="flex flex-col p-5 border-2 border-blue-200 [&>*]:m-4">
      <div className="flex flex-col">
        <label htmlFor="date" className="font-bold">
          Date
        </label>
        <input
          type="date"
          value={selectedDate}
          onChange={onDateInputChange}
          id="date"
        />
      </div>
      <div className="flex flex-col">
        <label htmlFor="time" className="font-bold">
          Time
        </label>
        <input
          type="time"
          id="time"
          value={selectedTime}
          onChange={onTimeInputChange}
        />
      </div>
      <button
        className="bg-blue-500 hover:bg-blue-400 text-white rounded p-2"
        onClick={submitButtonPressed}
      >
        + Add passage
      </button>
    </div>
  );
};

export default PassageForm;
