using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.Assessment.Api.Abstractions;
using System.Collections.Concurrent;
using LMS.Assessment.Api.Entities;

namespace LMS.Assessment.Api.Infrastructure;

public class LmsRepository
{
    public ConcurrentDictionary<int, LawFirm> _lawFirmStore = new();
    public ConcurrentDictionary<int, Lender> _lenderStore = new();

    public LawFirm GetLawFirmById(int id)
    {
        _lawFirmStore.TryGetValue(id, out var entity);
        // SimulateDbOperation();
        return entity ?? new LawFirm();
    }

    public List<LawFirm> GetAllLawFirms()
    {
        // SimulateDbOperation();
        return _lawFirmStore.Values.ToList();
    }

    public LawFirm CreateLawFirm(LawFirm entity)
    {
        _lawFirmStore.TryAdd(entity.Id, entity);
        // SimulateDbOperation();
        return entity;
    }

    public Lender GetLenderById(int id)
    {
        _lenderStore.TryGetValue(id, out var entity);
        // SimulateDbOperation();
        return entity ?? new Lender();
    }

    public List<Lender> GetAllLenders()
    {
        // SimulateDbOperation();
        return _lenderStore.Values.ToList();
    }

    public Lender CreateLender(Lender entity)
    {
        _lenderStore.TryAdd(entity.Id, entity);
        // SimulateDbOperation();
        return entity;
    }

    // private static void SimulateDbOperation()
    // {
    //     // Simulate some latency to mimic a real database operation
    //     Task.Delay(new Random().Next(40, 80));
    // }
}
